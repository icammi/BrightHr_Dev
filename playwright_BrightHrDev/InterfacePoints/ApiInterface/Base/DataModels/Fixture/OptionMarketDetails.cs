namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class OptionMarketDetails
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("FixtureId")]
        public long FixtureId { get; set; }

        [JsonPropertyName("Status")]
        public long Status { get; set; }

        [JsonPropertyName("NameId")]
        public long NameId { get; set; }

        [JsonPropertyName("SequenceNumber")]
        public long SequenceNumber { get; set; }

        [JsonPropertyName("DeadHeatDivisor")]
        public long DeadHeatDivisor { get; set; }

        [JsonPropertyName("DeadHeatDivisorForSerializationOnly")]
        public string DeadHeatDivisorForSerializationOnly { get; set; } = string.Empty;

        [JsonPropertyName("AggregatedStatus")]
        public long AggregatedStatus { get; set; }

        [JsonPropertyName("TotalMarketTemplateProbability")]
        public long TotalMarketTemplateProbability { get; set; }

        [JsonPropertyName("TotalMarketTemplateProbabilityForSerializationOnly")]
        public string TotalMarketTemplateProbabilityForSerializationOnly { get; set; } = string.Empty;

        [JsonPropertyName("ProbabilityCoverage")]
        public long ProbabilityCoverage { get; set; }

        [JsonPropertyName("Parameters")]
        public List<Parameter> Parameters { get; set; } = new();

        [JsonPropertyName("PriceMode")]
        public long PriceMode { get; set; }

        [JsonPropertyName("OptionMarketSpecials")]
        public long OptionMarketSpecials { get; set; }

        [JsonPropertyName("SettlementInformation")]
        public SettlementInformation SettlementInformation { get; set; } = new();

        [JsonPropertyName("IsEachWayAvailable")]
        public bool IsEachWayAvailable { get; set; }

        [JsonPropertyName("IsEachWay")]
        public bool IsEachWay { get; set; }

        [JsonPropertyName("PlaceTermsOrNull")]
        public PlaceTerms PlaceTermsOrNull { get; set; } = new();
    }
}
