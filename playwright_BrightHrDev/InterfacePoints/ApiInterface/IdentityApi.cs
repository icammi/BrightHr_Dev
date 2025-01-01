using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface
{
    public class IdentityApi : RestApi
    {
        private readonly IConfigurationRoot _configurationRoot;

        public IdentityApi(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
            BaseUrl = _configurationRoot.GetRequiredSection("Identity:TokenEndpoint").Value
                ?? throw new InvalidOperationException($"Could not find base url for {nameof(IdentityApi)}");
        }

        public async Task<TestedResponse<AccessTokenResponse>> GetConnectToken()
        {
            var headers = new Dictionary<string, IEnumerable<string>>
            {
                { "Authorization", new List<string>() { "Basic " + _configurationRoot.GetSection("Identity:AccessToken").Value } }
            };

            var form = new Dictionary<string, string>()
            {
                { "grant_type", "client_credentials" },
                { "scope", "vtos" }
            };

            var response = await PostForm<AccessTokenResponse>(string.Empty, form, headers);

            return response;
        }
    }
}
