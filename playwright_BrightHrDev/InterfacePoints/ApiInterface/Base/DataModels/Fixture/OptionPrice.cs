namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class OptionPrice
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("Context")]
        public OptionPriceContext Context { get; set; } = new();

        [JsonPropertyName("Price")]
        public Price Price { get; set; } = new();

        [JsonPropertyName("FiftyFiftyMargin")]
        public long FiftyFiftyMargin { get; set; }

        [JsonPropertyName("FiftyFiftyMarginForSerializationOnly")]
        public string FiftyFiftyMarginForSerializationOnly { get; set; } = string.Empty;

        [JsonPropertyName("OptionId")]
        public long OptionId { get; set; }

        [JsonPropertyName("SequenceNumber")]
        public long SequenceNumber { get; set; }

        [JsonPropertyName("OptionMarketId")]
        public long OptionMarketId { get; set; }

        [JsonPropertyName("Status")]
        public long Status { get; set; }

        [JsonPropertyName("IsEnabled")]
        public bool IsEnabled { get; set; }
    }
}
