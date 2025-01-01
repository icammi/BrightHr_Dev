namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class OptionMarket
    {
        [JsonPropertyName("OptionMarket")]
        public OptionMarketDetails OptionMarketDetails { get; set; } = new();

        [JsonPropertyName("Options")]
        public List<Option> Options { get; set; } = new();

        [JsonPropertyName("OptionPrices")]
        public List<OptionPrice> OptionPrices { get; set; } = new();

        [JsonPropertyName("OptionMarketComboPreventions")]
        public List<OptionMarketComboPrevention> OptionMarketComboPreventions { get; set; } = new();

        [JsonPropertyName("SequenceNumber")]
        public long SequenceNumber { get; set; }
    }
}
