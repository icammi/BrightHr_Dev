using playwright_newintegrationtests.InterfacePoints.ApiInterface;
using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders;
using playwright_newintegrationtests.InterfacePoints.DbInterface;

namespace playwright_newintegrationtests.StepDefinitions
{
    [Binding]
    public class CreateRequestforSettlementStepDefinitions
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IDataUtility _dataUtility;
        private readonly ISqlController _sqlController;
        private readonly ScenarioContext _scenarioContext;
        private readonly IdentityApi _identityApi;
        private readonly VtosApi _vtosApi;

        public CreateRequestforSettlementStepDefinitions(
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

        [Then(@"set the status for OptionMarketId to '([^']*)'")]
        public async Task StatusModifyForTheOptionMarketsAsync(String updatedStatus)
        {
            var modifyStatus = await _vtosApi.PostOptionMarketStatusModify(
                new StatusModifyRequestBuilder(_dataUtility)
                    .CreateStatusModifyRequest()
                    .WithStatus(updatedStatus).Build());

            using (new AssertionScope())
            {
                modifyStatus.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    because: "We expected the request to be successful but return no data", modifyStatus);
                modifyStatus.Result?.Data.Count.Should().Be(0, because: "We didn't expect to recieve any data",
                    modifyStatus);
            }
        }

        [Then(@"settlement request should be created with  '([^']*)', '([^']*)'")]
        public async Task CreateSettlementRequestForTheOptionMarketsAsync(int PayoutRequestSourceType, bool IgnoreOverridableValidations)
        {
            var createSettlement = await _vtosApi.PostCreateSettlementRequest(
                new CreateSettlementRequestBuilder(_dataUtility)
                    .CreateSettlementRequest()
                    .WithPayoutRequestSourceType(PayoutRequestSourceType)
                    .WithIgnoreOverridableValidations(IgnoreOverridableValidations)
                    .Build());

            using (new AssertionScope())
            {
                createSettlement.StatusCode.Should().Be(HttpStatusCode.NoContent,
                    because: "We expected the request to be successful but return no data", createSettlement);
                createSettlement.Result?.Data.Count.Should().Be(0, because: "We didn't expect to recieve any data",
                    createSettlement);
            }
        }
    }
}


