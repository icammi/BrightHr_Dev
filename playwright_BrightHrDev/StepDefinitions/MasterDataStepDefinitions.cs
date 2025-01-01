using playwright_newintegrationtests.Constants;
using playwright_newintegrationtests.InterfacePoints.DbInterface;
using playwright_newintegrationtests.InterfacePoints.DbInterface.Base.DataModels;

namespace playwright_newintegrationtests.StepDefinitions
{
    [Binding]
    public class MasterDataStepDefinitions
    {
        private readonly ISqlController _sqlController;
        private readonly ScenarioContext _scenarioContext;

        public MasterDataStepDefinitions(ISqlController sqlController, ScenarioContext scenarioContext)
        {
            _sqlController = sqlController;
            _scenarioContext = scenarioContext;
        }

        [Given(@"user has access to the masterdata")]
        public void GivenUserHasAccessToTheMasterdata()
        {
            _sqlController.CanConnect(SqlConnectionStringConstants.VTrading)
                .Should().BeTrue(because: "We need to be able to access the database to run this test");
        }

        [When(@"user gets data for '([^']*)'")]
        public void WhenUserGetsDataFor(string lookupType)
        {
            var sqlCommand = lookupType.ToLower() switch
            {
                "tagtype" => Sql.GetTagTypes,
                "attribute" => Sql.GetAttributeTypes,
                "fixtureparticipantstatus" => Sql.GetParticipantStatusTypes,
                "optionstatus" => Sql.GetOptionStatusTypes,
                "fixturetype" => Sql.GetFixtureTypes,
                _ => throw new InvalidOperationException($"Unexpected value: {lookupType}")
            };

            var result = _sqlController.RunCommand<LookupData>(SqlConnectionStringConstants.VTrading, sqlCommand);

            _scenarioContext.Set(result, ScenarioContextKeys.LookupDataResult);
        }

        [Then(@"the following data should be available: '([^']*)'")]
        public void ThenTheFollowingDataShouldBeAvailable(string expected)
        {
            var expectedValues = expected.ToLower().Split(", ");
            var actualValues = _scenarioContext.Get<IEnumerable<LookupData>>(ScenarioContextKeys.LookupDataResult)?.ToList() ?? new();

            using (new AssertionScope())
            {
                expectedValues.Length.Should().Be(actualValues.Count);
                foreach (var value in actualValues)
                {
                    expectedValues.Any(itm => itm == value.Name.ToLower())
                        .Should().BeTrue(because: $"Found {value} when we were only expecting {expected}", expectedValues);
                }
            }
        }
    }
}
