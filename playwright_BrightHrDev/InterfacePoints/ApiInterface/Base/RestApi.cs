namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base
{
    public class RestApi
    {
        protected string BaseUrl { get; set; } = string.Empty;

        public RestApi() { }

        protected async Task<TestedResponse<TRes>>? Get<TRes>(string endpoint, IDictionary<string, IEnumerable<string>>? headers = null)
            where TRes : class, new()
        {
            using var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };

            ApplyHeaders(headers, httpClient);

            var response = await httpClient.GetAsync(endpoint);

            return await GenerateTestedResponse<TRes>(response);
        }

        protected async Task<TestedResponse<TRes>> PostJson<TReq, TRes>(string endpoint, TReq? requestBody, IDictionary<string, IEnumerable<string>>? headers = null)
            where TReq : class, new()
            where TRes : class, new()
        {
            using var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };

            ApplyHeaders(headers, httpClient);

            var response = await httpClient.PostAsJsonAsync(endpoint, requestBody);

            return await GenerateTestedResponse<TRes>(response);
        }

        protected async Task<TestedResponse<TRes>> PostForm<TRes>(string endpoint, IEnumerable<KeyValuePair<string, string>> requestBody, IDictionary<string, IEnumerable<string>>? headers = null)
            where TRes : class, new()
        {
            using var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl),
            };

            ApplyHeaders(headers, httpClient);

            using var content = new FormUrlEncodedContent(requestBody);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync(endpoint, content);

            return await GenerateTestedResponse<TRes>(response);
        }

        private static async Task<TestedResponse<TRes>> GenerateTestedResponse<TRes>(HttpResponseMessage response) where TRes : class, new()
        {
            var responseText = await response.Content.ReadAsStringAsync();
            var testedResponse = new TestedResponse<TRes>
            {
                StatusCode = response.StatusCode,
                IsSuccess = response.IsSuccessStatusCode
            };

            if (testedResponse.IsSuccess)
            {
                testedResponse.Result = responseText.Length > 0 ? JsonSerializer.Deserialize<TRes>(responseText) : new TRes();
            }
            else
            {
                testedResponse.Errors.Add(responseText);
            }

            return testedResponse;
        }

        private static void ApplyHeaders(IDictionary<string, IEnumerable<string>>? headers, HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }
    }
}
