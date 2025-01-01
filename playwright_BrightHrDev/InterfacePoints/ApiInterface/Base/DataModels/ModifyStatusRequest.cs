namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels
{
    public class ModifyStatusRequest
    {
        [JsonPropertyName("Status")]
        public int Status { get; set; } = 1;

        [JsonPropertyName("ResultStatus")]
        public int ResultStatus { get; set; } = 3;

    }
}
