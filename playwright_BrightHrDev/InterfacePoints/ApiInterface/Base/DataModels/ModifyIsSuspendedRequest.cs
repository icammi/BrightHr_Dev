namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels
{
    public class ModifyIsSuspendedRequest
    {
        [JsonPropertyName("IsSuspended")]
        public bool IsSuspended { get; set; } = false;
    }
}
