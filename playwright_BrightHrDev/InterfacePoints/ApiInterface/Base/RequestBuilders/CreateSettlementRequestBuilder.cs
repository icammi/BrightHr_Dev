using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders;

public class CreateSettlementRequestBuilder
{
    private readonly IDataUtility _dataUtility;

    private CreateSettlementRequest _createSettlementRequest = new();
    private const string ExampleRequestFile = "CreateSettlement.json";

    public CreateSettlementRequestBuilder(IDataUtility dataUtility)
    {
        _dataUtility = dataUtility;
    }

    public CreateSettlementRequestBuilder CreateSettlementRequest()
    {
        var exampleData = _dataUtility.GetJsonFileData(ExampleRequestFile);

        _createSettlementRequest = JsonSerializer.Deserialize<CreateSettlementRequest>(exampleData) ?? new CreateSettlementRequest();
        return this;
    }

    public CreateSettlementRequestBuilder WithPayoutRequestSourceType(int PayoutRequestSourceType)
    {
        _createSettlementRequest.PayoutRequestSourceType = PayoutRequestSourceType;

        return this;
    }

    public CreateSettlementRequestBuilder WithIgnoreOverridableValidations(bool IgnoreOverridableValidations)
    {
        _createSettlementRequest.IgnoreOverridableValidations = IgnoreOverridableValidations;

        return this;
    }

    public CreateSettlementRequest Build()
    {
        return _createSettlementRequest;
    }
}

