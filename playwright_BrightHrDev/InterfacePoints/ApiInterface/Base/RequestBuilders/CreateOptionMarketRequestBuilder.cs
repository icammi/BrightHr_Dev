using Parameter = playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.OptionMarkets.Parameter;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders
{
    public class CreateOptionMarketRequestBuilder
    {
        private readonly IDataUtility _dataUtility;
        private const string ExampleRequestFile = "CreateOptionMarketV3.json";

        private CreateOptionMarketRequest _createOptionMarket = new();

        public CreateOptionMarketRequestBuilder(IDataUtility dataUtility)
        {
            _dataUtility = dataUtility;
        }

        public CreateOptionMarketRequestBuilder CreateOptionMarketRequest()
        {
            var exampleData = _dataUtility.GetJsonFileData(ExampleRequestFile);

            _createOptionMarket = JsonSerializer.Deserialize<CreateOptionMarketRequest>(exampleData) ?? new();

            return this;
        }

        public CreateOptionMarketRequestBuilder WithName(string name)
        {
            _createOptionMarket.Name = name;
            return this;
        }

        public CreateOptionMarketRequestBuilder WithMarketTemplateId(long marketTemplateId)
        {
            _createOptionMarket.OptionMarketTemplateId = marketTemplateId;
            return this;
        }

        public CreateOptionMarketRequestBuilder WithOption(CreateOption option)
        {
            option.SortOrder = _createOptionMarket.Options.Count;
            _createOptionMarket.Options.Add(option);
            return this;
        }

        public CreateOptionMarketRequestBuilder WithParameter(Parameter parameter)
        {
            _createOptionMarket.Parameters.Add(parameter);
            return this;
        }

        public CreateOptionMarketRequest Build()
        {
            return _createOptionMarket;
        }
    }
}
