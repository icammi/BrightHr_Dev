namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base
{
    public class TestedResponse<TRes>
        where TRes : class, new()
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; } = false;
        public List<string> Errors { get; set; } = new();
        public TRes? Result { get; set; } = default;
    }
}
