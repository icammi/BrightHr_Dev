namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class OptionMarketComboPrevention
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("OptionMarketId")]
        public long OptionMarketId { get; set; }

        [JsonPropertyName("Context")]
        public OptionMarketComboPreventionContext Context { get; set; } = new();

        [JsonPropertyName("ComboPrevention")]
        public long ComboPrevention { get; set; }

        [JsonPropertyName("MinCombo")]
        public long MinCombo { get; set; }

        [JsonPropertyName("SequenceNumber")]
        public long SequenceNumber { get; set; }
    }
}
