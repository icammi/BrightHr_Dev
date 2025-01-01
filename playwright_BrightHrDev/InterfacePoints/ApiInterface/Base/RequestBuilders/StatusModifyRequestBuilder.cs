using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders;

public class StatusModifyRequestBuilder
{
    private readonly IDataUtility _dataUtility;

    private StatusModifyRequest _statusModify = new();
    private const string ExampleRequestFile = "StatusModify.json";

    public StatusModifyRequestBuilder(IDataUtility dataUtility)
    {
        _dataUtility = dataUtility;
    }

    public StatusModifyRequestBuilder CreateStatusModifyRequest()
    {
        var exampleData = _dataUtility.GetJsonFileData(ExampleRequestFile);

        _statusModify = JsonSerializer.Deserialize<StatusModifyRequest>(exampleData) ?? new StatusModifyRequest();
        return this;
    }

    public StatusModifyRequestBuilder WithStatus(String resultStatusText)
    {
        _statusModify.Status = GetOptionMarketResultStatus(resultStatusText);
        return this;
    }

    public static int GetOptionMarketResultStatus(string resultStatusText)
    {
        return resultStatusText.ToLower() switch
        {
            "visible" => 1,
            "suspended" => 2,
            "hidden" => 3,
            _ => throw new InvalidOperationException($"{resultStatusText} is invalid")
        };
    }

    public StatusModifyRequest Build()
    {
        return _statusModify;
    }
}

