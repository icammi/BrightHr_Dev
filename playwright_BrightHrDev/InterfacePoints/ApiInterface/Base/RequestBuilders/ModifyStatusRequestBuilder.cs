using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders
{
    public class ModifyStatusRequestBuilder
    {
        private ModifyStatusRequest _modifyStatusRequest = new();

        public ModifyStatusRequestBuilder CreateModifyStatusRequest()
        {
            _modifyStatusRequest = new ModifyStatusRequest();
            return this;
        }

        public ModifyStatusRequestBuilder WithStatus(string statusText)
        {
            _modifyStatusRequest.Status = GetStatus(statusText);
            return this;
        }

        public ModifyStatusRequestBuilder WithResultStatus(string resultStatusText)
        {
            _modifyStatusRequest.ResultStatus = GetStatus(resultStatusText);
            return this;
        }

        public ModifyStatusRequest Build()
        {
            return _modifyStatusRequest;
        }

        public static int GetStatus(string statusText)
        {
            return statusText.ToLower() switch
            {
                "created" => 1,
                "published" => 2,
                "unpublished" => 3,
                "abandoned" => 4,
                "postponed" => 5,
                "cancelled" => 6,
                _ => throw new InvalidOperationException($"{statusText} is invalid")
            };
        }
    }
}
