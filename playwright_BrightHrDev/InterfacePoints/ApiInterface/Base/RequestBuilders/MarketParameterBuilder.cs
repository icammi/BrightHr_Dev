using Parameter = playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.OptionMarkets.Parameter;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders
{
    public class MarketParameterBuilder
    {
        private readonly IDataUtility _dataUtility;
        private const string ExampleRequestFile = "Parameter.json";

        private Parameter _parameter = new();

        public MarketParameterBuilder(IDataUtility dataUtility)
        {
            _dataUtility = dataUtility;
        }

        public MarketParameterBuilder CreateOptionMarketRequest()
        {
            var exampleData = _dataUtility.GetJsonFileData(ExampleRequestFile);

            _parameter = JsonSerializer.Deserialize<Parameter>(exampleData) ?? new();
            _parameter.IsEmpty = true;

            return this;
        }

        public MarketParameterBuilder WithKey(string key)
        {
            _parameter.Key = key;
            return this;
        }

        public MarketParameterBuilder WithValue(string value)
        {
            _parameter.ValueAsString = value;
            _parameter.IsEmpty = false;
            return this;
        }

        public Parameter Build()
        {
            return _parameter;
        }
    }
}
