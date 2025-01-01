using System.Text.Json.Serialization;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels
{
    public class ModifyOptionMarketStatusRequest
    {
        [JsonPropertyName("ResultStatus")]
        public long ResultStatus { get; set; } = 3;
    }
}
