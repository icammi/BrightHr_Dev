using playwright_newintegrationtests.Constants;
using playwright_newintegrationtests.InterfacePoints.ApiInterface;
using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders;
using playwright_newintegrationtests.InterfacePoints.DbInterface;

namespace playwright_newintegrationtests.StepDefinitions
{
    [Binding]
    public class OptionMarketsStepDefinitions
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IDataUtility _dataUtility;
        private readonly ISqlController _sqlController;
        private readonly ScenarioContext _scenarioContext;
        private readonly IdentityApi _identityApi;
        private readonly VtosApi _vtosApi;
        public OptionMarketsStepDefinitions(
            IConfigurationRoot configurationRoot,
            IDataUtility dataUtility,
            ISqlController sqlController,
            ScenarioContext scenarioContext)
        {
            _configurationRoot = configurationRoot;
            _dataUtility = dataUtility;
            _sqlController = sqlController;
            _scenarioContext = scenarioContext;
            _identityApi = new(_configurationRoot);
            _vtosApi = new VtosApi(_configurationRoot, _scenarioContext);
        }

        [When(@"An option market has been created")]
        public async Task OptionMarketHasBeenCreated()
        {
            var optionMarketResponse = await _vtosApi.PostCreateOptionMarket(
                new CreateOptionMarketRequestBuilder(_dataUtility).CreateOptionMarketRequest().Build()
            );

            using (new AssertionScope())
            {
                optionMarketResponse.IsSuccess.Should().BeTrue(because: "We expected the option market to be created",
                    optionMarketResponse);
                optionMarketResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                optionMarketResponse.Result?.OptionMarketId.Should().BeGreaterThan(0);
            }

            _scenarioContext.Set(optionMarketResponse.Result?.OptionMarketId, ScenarioContextKeys.OptionMarketId);
        }

        [Then(@"the StatusResult of the market have been modified to '([^']*)'")]
        public async Task StatusResultOfTheMarketHaveBeenModifiedAsync(String updatedStatus)
        {
            var expectedOptionId = _scenarioContext.Get<long>(ScenarioContextKeys.OptionMarketId);

            var optionMarket = _sqlController.RunCommand<ModifyOption>(SqlConnectionStringConstants.VTrading,
                Sql.GetOptionMarketModifyStatus, new List<SqlParameter>
                {
                    new() { ParameterName = "@OptionMarketId", Value = expectedOptionId },
                }
            )?.ToList().FirstOrDefault();

            optionMarket.Should().NotBeNull();

            if (optionMarket == null) throw new InvalidOperationException();

            _scenarioContext.Set(optionMarket.OptionId, ScenarioContextKeys.OptionId);


            var modifyOptionMarketRequestBuilder = new ModifyOptionMarketRequestBuilder(_dataUtility);
            modifyOptionMarketRequestBuilder.CreateModifyOptionMarketRequest();

            var modifyResultStatus = await _vtosApi.PostOptionMarketModifyStatus(
                new ModifyOptionMarketRequestBuilder(_dataUtility)
                    .CreateModifyOptionMarketRequest()
                    .WithOption(
                     new ModifyOptionBuilder()
                            .WithOptionId(optionMarket.OptionId)
                            .WithResultStatus(updatedStatus)
                            .Build()
                    ).Build());

            using (new AssertionScope())
            {
                modifyResultStatus.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    because: "We expected the request to be successful but return no data", modifyResultStatus);
                modifyResultStatus.Result?.Data.Count.Should().Be(0, because: "We didn't expect to recieve any data",
                    modifyResultStatus);
            }
        }

        [Then(@"the resultset of the marketID's has been modified to '([^']*)'")]
        public async Task ResultsetOfTheMarketIDsHasBeenModifiedAsync(String updatedStatus)
        {
            var expectedOptionId = _scenarioContext.Get<long>(ScenarioContextKeys.OptionMarketId);

            var optionMarkets = _sqlController.RunCommand<ModifyOption>(SqlConnectionStringConstants.VTrading,
                Sql.GetOptionMarketModifyStatus, new List<SqlParameter>
                {
                    new() { ParameterName = "@OptionMarketId", Value = expectedOptionId },
                }
            )?.ToList();

            optionMarkets.Should().NotBeNull();
            optionMarkets.Should().HaveCountGreaterThan(0);


            if (optionMarkets == null) throw new InvalidOperationException();

            var modifyOptionMarketRequestBuilder = new ModifyOptionMarketRequestBuilder(_dataUtility);
            modifyOptionMarketRequestBuilder.CreateModifyOptionMarketRequest();

            foreach (var optionMarket in optionMarkets)
            {
                modifyOptionMarketRequestBuilder.WithOption(
                     new ModifyOptionBuilder()
                             .WithOptionId(optionMarket.OptionId)
                             .WithResultStatus(updatedStatus)
                             .Build()
                     ).Build();

            }

            var modifyResultStatus = await _vtosApi.PostOptionMarketModifyStatus(modifyOptionMarketRequestBuilder.Build());

            using (new AssertionScope())
            {
                modifyResultStatus.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    because: "We expected the request to be successful but return no data", modifyResultStatus);
                modifyResultStatus.Result?.Data.Count.Should().Be(0, because: "We didn't expect to recieve any data",
                    modifyResultStatus);
            }
        }

        [Then(@"the modified results should be visible as '([^']*)'")]
        public async Task ShouldSeeTheModifiedTestResultsAsync(string updatedStatus)
        {
            var expectedStatus = ModifyOptionBuilder.GetOptionMarketResultStatus(updatedStatus);
            var expectedOptionId = _scenarioContext.Get<long>(ScenarioContextKeys.OptionId);

            var expectedOptionMarketId = _scenarioContext.Get<long>(ScenarioContextKeys.OptionMarketId);

            var optionMarket = _sqlController.RunCommand<ModifyOption>(SqlConnectionStringConstants.VTrading,
                Sql.GetOptionMarketById, new List<SqlParameter>
                {
                    new() { ParameterName = "@OptionMarketId", Value = expectedOptionMarketId },
                    new() { ParameterName = "@OptionId", Value = expectedOptionId }
                }
            )?.ToList().FirstOrDefault();

            using (new AssertionScope())
            {
                optionMarket.Should().NotBeNull();
                optionMarket?.OptionId.Should().Be(expectedOptionId);
                optionMarket?.ResultStatus.Should().Be(expectedStatus.ToString());
                optionMarket?.OptionMarketId.Should().Be(expectedOptionMarketId);
            }
        }
    }
}
