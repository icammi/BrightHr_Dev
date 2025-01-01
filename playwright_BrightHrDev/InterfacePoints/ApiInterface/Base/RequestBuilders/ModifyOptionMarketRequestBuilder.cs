using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders;

public class ModifyOptionMarketRequestBuilder
{
    private readonly IDataUtility _dataUtility;

    private ModifyOptionMarketRequest _modifyOptionMarket = new();
    private const string ExampleRequestFile = "ModifyOptionMarketV2.json";

    public ModifyOptionMarketRequestBuilder(IDataUtility dataUtility)
    {
        _dataUtility = dataUtility;
    }

    public ModifyOptionMarketRequestBuilder CreateModifyOptionMarketRequest()
    {
        var exampleData = _dataUtility.GetJsonFileData(ExampleRequestFile);

        _modifyOptionMarket = JsonSerializer.Deserialize<ModifyOptionMarketRequest>(exampleData) ?? new ModifyOptionMarketRequest();
        _modifyOptionMarket.Options = new List<ModifyOption>();
        return this;
    }

    public ModifyOptionMarketRequestBuilder WithOption(ModifyOption option)
    {
        _modifyOptionMarket.Options.Add(option);
        return this;
    }

    public ModifyOptionMarketRequest Build()
    {
        return _modifyOptionMarket;
    }
}