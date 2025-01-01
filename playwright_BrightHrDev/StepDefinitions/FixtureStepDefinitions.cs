using playwright_newintegrationtests.Constants;
using playwright_newintegrationtests.InterfacePoints.ApiInterface;
using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base;
using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels;
using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders;
using playwright_newintegrationtests.InterfacePoints.DbInterface;

namespace playwright_newintegrationtests.StepDefinitions
{
    [Binding]
    public class FixtureStepDefinitions
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IDataUtility _dataUtility;
        private readonly IKafkaReader _kafkaReader;
        private readonly ISqlController _sqlController;
        private readonly ScenarioContext _scenarioContext;
        private readonly IdentityApi _identityApi;
        private readonly VtosApi _vtosApi;

        public FixtureStepDefinitions(
            IConfigurationRoot configurationRoot,
            IDataUtility dataUtility,
            IKafkaReader kafkaReader,
            ISqlController sqlController,
            ScenarioContext scenarioContext)
        {
            _configurationRoot = configurationRoot;
            _dataUtility = dataUtility;
            _kafkaReader = kafkaReader;
            _sqlController = sqlController;
            _scenarioContext = scenarioContext;
            _identityApi = new(_configurationRoot);
            _vtosApi = new VtosApi(_configurationRoot, _scenarioContext);
        }

        [Given(@"Fixture has been created for '([^']*)'")]
        public async Task GivenAFixtureHasBeenCreatedWithAStatusOf(string sport)
        {
            var identityToken = await _identityApi.GetConnectToken();
            _scenarioContext.Add(ScenarioContextKeys.IdentityToken, identityToken.Result);
            _scenarioContext.Add(ScenarioContextKeys.Sport, sport);
            var pairGameRequest = CreatePairGame(sport);
            var pairGame = await _vtosApi.PostCreatePairGame(
                pairGameRequest.Build()
            );

            using (new AssertionScope())
            {
                pairGame.Result.Should().NotBeNull(because: "We expected a fixture to have been created", pairGame);
            }
            AssertPairGameCreated(pairGame);

        }
        private PairGameRequestBuilder CreatePairGame(string sport)
        {
            var homeParticipantId = _configurationRoot.GetSection($"DefaultData:{sport}:HomeParticipantId");
            var awayParticipantId = _configurationRoot.GetSection($"DefaultData:{sport}:AwayParticipantId");

            var pairGameRequest = new PairGameRequestBuilder(_dataUtility).CreateAPairGame();
            if (homeParticipantId?.Value != null)
            {
                pairGameRequest.WithHomeParticipant(int.Parse(homeParticipantId.Value));
            }

            if (awayParticipantId?.Value != null)
            {
                pairGameRequest.WithAwayParticipant(int.Parse(awayParticipantId.Value));
            }

            return pairGameRequest;
        }

        [When(@"a client changes fixture status to '([^']*)'")]
        public async Task WhenAClientRequestsFixtureStatusToBeChangedTo(string updatedStatus)
        {
            var modifyStatus = await _vtosApi.PostModifyStatus(
                new ModifyStatusRequestBuilder()
                    .CreateModifyStatusRequest()
                    .WithStatus(updatedStatus)
                    .Build()
            );

            using (new AssertionScope())
            {
                modifyStatus.StatusCode.Should().Be(HttpStatusCode.NoContent, because: "We expected the request to be successful but return no data", modifyStatus);
                modifyStatus.Result?.Data.Count.Should().Be(0, because: "We didn't expect to recieve any data", modifyStatus);
            }
        }

        [Then(@"the fixture status should be '([^']*)'")]
        public async Task ThenTheStatusIsModifiedSuccessfullyAs(string updatedStatus)
        {
            var getFixture = await _vtosApi.PostGetFullFixture(new GetFullFixtureRequest());
            var expectedStatus = ModifyStatusRequestBuilder.GetStatus(updatedStatus);
            var expectedFixture = _scenarioContext.Get<long>(ScenarioContextKeys.FixtureId);

            var fixtureFromDb = _sqlController.RunCommand<FixtureData>(
                SqlConnectionStringConstants.VTrading,
                Sql.GetFixtureData,
                new List<SqlParameter>()
                {
                    new() { ParameterName = "@FixtureId", Value = expectedFixture },
                    new() { ParameterName = "@StatusId", Value = expectedStatus }
                }
            )?.ToList().FirstOrDefault();

            using (new AssertionScope())
            {
                getFixture.IsSuccess.Should().BeTrue(because: "The request should've been successful");
                getFixture.StatusCode.Should().Be(HttpStatusCode.OK, because: "We expected to get a successful response (200:OK)");
                getFixture.Result.Should().NotBeNull(because: "We expected to get the fixture details back", getFixture);

                fixtureFromDb.Should().NotBeNull(because: "We should've got data back from the database");

                var apiFixture = getFixture.Result?.FixtureDataOrNull;
                apiFixture.Should().NotBeNull(because: "We requested the fixture Data to be returned", getFixture.Result);
                apiFixture?.Id.Should().Be(expectedFixture, because: $"The fixture ID should match the one requested ({expectedFixture})", getFixture.Result);
                apiFixture?.Status.Should().Be(expectedStatus, because: $"We expected the fixture to be updated to status {updatedStatus}({expectedStatus})", getFixture.Result);

                fixtureFromDb?.Id.Should().Be(apiFixture?.Id);
                fixtureFromDb?.NameId.Should().Be(apiFixture?.NameId);
                fixtureFromDb?.Status.Should().Be(apiFixture?.Status);
                bool? expectedIsSuspended = fixtureFromDb?.IsSuspended;
                expectedIsSuspended.Should().Be(apiFixture?.IsSuspended);
            }
        }
        private FixtureData? GetStatusIdFromSql(long expectedFixture, long expectedStatus)
        {
            return _sqlController.RunCommand<FixtureData>(
               SqlConnectionStringConstants.VTrading,
               Sql.GetFixtureData,
               new List<SqlParameter>()
               {
                    new() { ParameterName = "@FixtureId", Value = expectedFixture },
                    new() { ParameterName = "@StatusId", Value = expectedStatus }
               }
           )?.ToList().FirstOrDefault();
        }
        private void AssertPairGameCreated(TestedResponse<PairGameResponse> pairGame)
        {
            var fixtureId = pairGame.Result?.FixtureId;

            using (new AssertionScope())
            {
                pairGame.Result.Should().NotBeNull(because: "We expected a fixture to have been created", pairGame);
                fixtureId.Should().NotBeNull(because: "We expected a fixtureID to be returned");

                var createdStatus = ModifyStatusRequestBuilder.GetStatus("created");
                var sqlResponse = GetStatusIdFromSql(fixtureId ?? 0, createdStatus);

                sqlResponse.Should().NotBeNull(because: "We expected the data to be stored");
                sqlResponse?.Status.Should().Be(createdStatus, because: "The fixture was just created");
            }
            _scenarioContext.Add(ScenarioContextKeys.FixtureId, fixtureId);
        }
    }
}
