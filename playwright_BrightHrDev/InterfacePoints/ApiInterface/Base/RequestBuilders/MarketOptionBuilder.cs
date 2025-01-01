using Parameter = playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.OptionMarkets.Parameter;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders
{
    public class MarketOptionBuilder
    {
        private readonly IDataUtility _dataUtility;
        private const string ExampleRequestFile = "CreateOption.json";

        private CreateOption _option = new();

        public MarketOptionBuilder(IDataUtility dataUtility)
        {
            _dataUtility = dataUtility;
        }

        public MarketOptionBuilder CreateOptionMarketRequest()
        {
            var exampleData = _dataUtility.GetJsonFileData(ExampleRequestFile);

            _option = JsonSerializer.Deserialize<CreateOption>(exampleData) ?? new CreateOption();

            return this;
        }

        public MarketOptionBuilder WithName(string name)
        {
            _option.Name = name;
            return this;
        }

        //public MarketOptionBuilder WithPrice(Price price)
        //{
        //    _option.PriceOrNull = price;
        //    return this;
        //}

        public MarketOptionBuilder WithParameter(Parameter parameter)
        {
            _option.Parameters.Add(parameter);
            return this;
        }

        public MarketOptionBuilder WithMargin(float margin)
        {
            _option.FiftyFiftyMargin = margin;
            _option.FiftyFiftyMarginForSerializationOnly = margin.ToString();
            return this;
        }

        public CreateOption Build()
        {
            return _option;
        }
    }
}
