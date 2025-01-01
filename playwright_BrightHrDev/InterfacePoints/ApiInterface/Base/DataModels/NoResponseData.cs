namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels
{
    public class NoResponseData
    {
        [JsonExtensionData]
        public Dictionary<string, object> Data { get; set; } = new();
    }
}
