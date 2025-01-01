namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels
{
    public class StatusModifyRequest
    {
        [JsonPropertyName("Status")]
        public int Status { get; set; } = 1;

    }
}
