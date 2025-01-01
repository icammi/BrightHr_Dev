using playwright_newintegrationtests.Constants;
using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base;
using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface
{
    public class VtosApi : RestApi
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly ScenarioContext _scenarioContext;

        public VtosApi(IConfigurationRoot configurationRoot, ScenarioContext scenarioContext)
        {
            _configurationRoot = configurationRoot;
            _scenarioContext = scenarioContext;
            BaseUrl = _configurationRoot.GetRequiredSection("Shared:BaseUrl").Value
                ?? throw new InvalidOperationException($"Could not find base url for {nameof(VtosApi)}");
        }

        public async Task<TestedResponse<PairGameResponse>> PostCreatePairGame(PairGameRequest requestBody)
        {
            var headers = CreateAuthenticationHeaders();
            var endpoint = string.Format(
                VtosApiEndpointConstants.CreatePairGame,
                _scenarioContext.Get<string>(ScenarioContextKeys.Sport)
            );

            return await PostJson<PairGameRequest, PairGameResponse>(endpoint, requestBody, headers);
        }

        public async Task<TestedResponse<NoResponseData>> PostModifyStatus(ModifyStatusRequest requestBody)
        {
            var headers = CreateAuthenticationHeaders();
            var endpoint = string.Format(
                VtosApiEndpointConstants.ModifyStatus,
                _scenarioContext.Get<string>(ScenarioContextKeys.Sport),
                _scenarioContext.Get<long>(ScenarioContextKeys.FixtureId).ToString()
            );

            return await PostJson<ModifyStatusRequest, NoResponseData>(endpoint, requestBody, headers);
        }

        public async Task<TestedResponse<NoResponseData>> PostModifyIsSuspended(ModifyIsSuspendedRequest requestBody)
        {
            var headers = CreateAuthenticationHeaders();
            var endpoint = string.Format(
                VtosApiEndpointConstants.ModifyIsSuspended,
                _scenarioContext.Get<string>(ScenarioContextKeys.Sport),
                _scenarioContext.Get<long>(ScenarioContextKeys.FixtureId).ToString()
            );

            return await PostJson<ModifyIsSuspendedRequest, NoResponseData>(endpoint, requestBody, headers);
        }

        public async Task<TestedResponse<GetFullFixtureResponse>> PostGetFullFixture(GetFullFixtureRequest requestBody)
        {
            var headers = CreateAuthenticationHeaders();
            var endpoint = string.Format(
                VtosApiEndpointConstants.GetFullFixture,
                _scenarioContext.Get<string>(ScenarioContextKeys.Sport),
                _scenarioContext.Get<long>(ScenarioContextKeys.FixtureId).ToString()
            );

            return await PostJson<GetFullFixtureRequest, GetFullFixtureResponse>(endpoint, requestBody, headers);
        }

        public async Task<TestedResponse<CreateOptionMarketResponse>> PostCreateOptionMarket(CreateOptionMarketRequest requestBody)
        {
            var headers = CreateAuthenticationHeaders();
            var endpoint = string.Format(
                VtosApiEndpointConstants.CreateOptionMarket,
                _scenarioContext.Get<string>(ScenarioContextKeys.Sport),
                _scenarioContext.Get<long>(ScenarioContextKeys.FixtureId).ToString()
                );

            return await PostJson<CreateOptionMarketRequest, CreateOptionMarketResponse>(endpoint, requestBody, headers);
        }

        private Dictionary<string, IEnumerable<string>> CreateAuthenticationHeaders()
        {
            var identityToken = _scenarioContext.Get<AccessTokenResponse>(ScenarioContextKeys.IdentityToken);
            var headers = new Dictionary<string, IEnumerable<string>>
            {
                { "Authorization", new List<string>() { $"{identityToken.TokenType} {identityToken.AccessToken}" } }
            };
            return headers;
        }

        public async Task<TestedResponse<NoResponseData>> PostOptionMarketModifyStatus(ModifyOptionMarketRequest requestBody)
        {
            var headers = CreateAuthenticationHeaders();
            var endpoint = string.Format(
                VtosApiEndpointConstants.ModifyResults,
                _scenarioContext.Get<string>(ScenarioContextKeys.Sport),
                _scenarioContext.Get<long>(ScenarioContextKeys.FixtureId).ToString(),
                _scenarioContext.Get<long>(ScenarioContextKeys.OptionMarketId).ToString()
            );

            return await PostJson<ModifyOptionMarketRequest, NoResponseData>(endpoint, requestBody, headers);
        }

        public async Task<TestedResponse<NoResponseData>> PostOptionMarketStatusModify(StatusModifyRequest requestBody)
        {
            var headers = CreateAuthenticationHeaders();
            var endpoint = string.Format(
                VtosApiEndpointConstants.StatusModify,
                _scenarioContext.Get<string>(ScenarioContextKeys.Sport),
                _scenarioContext.Get<long>(ScenarioContextKeys.FixtureId).ToString(),
                _scenarioContext.Get<long>(ScenarioContextKeys.OptionMarketId).ToString()
            );

            return await PostJson<StatusModifyRequest, NoResponseData>(endpoint, requestBody, headers);
        }

        public async Task<TestedResponse<NoResponseData>> PostCreateSettlementRequest(CreateSettlementRequest requestBody)
        {
            var headers = CreateAuthenticationHeaders();
            var endpoint = string.Format(
                VtosApiEndpointConstants.SettlementRequestsCreate,
                _scenarioContext.Get<string>(ScenarioContextKeys.Sport),
                _scenarioContext.Get<long>(ScenarioContextKeys.FixtureId).ToString(),
                _scenarioContext.Get<long>(ScenarioContextKeys.OptionMarketId).ToString()
            );

            return await PostJson<CreateSettlementRequest, NoResponseData>(endpoint, requestBody, headers);
        }
    }
}
