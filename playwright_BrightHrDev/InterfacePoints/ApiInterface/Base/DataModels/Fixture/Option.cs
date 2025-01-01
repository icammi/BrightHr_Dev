namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class Option
    {
        [SqlDataField("fId")]
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [SqlDataField("frOptionMarketId")]
        [JsonPropertyName("OptionMarketId")]
        public long OptionMarketId { get; set; }

        [JsonPropertyName("NameId")]
        public long NameId { get; set; }

        [JsonPropertyName("EffectiveStatus")]
        public long EffectiveStatus { get; set; }

        [SqlDataField("frResultStatusId")]
        [JsonPropertyName("ResultStatus")]
        public long ResultStatus { get; set; }

        [JsonPropertyName("CancellationReason")]
        public SettlementFinishedForSerializationOnly CancellationReason { get; set; } = new();

        [JsonPropertyName("SequenceNumber")]
        public long SequenceNumber { get; set; }

        [JsonPropertyName("Status")]
        public long Status { get; set; }

        [JsonPropertyName("AggregatedStatus")]
        public long AggregatedStatus { get; set; }

        [JsonPropertyName("SortOrder")]
        public long SortOrder { get; set; }

        [JsonPropertyName("Probability")]
        public long Probability { get; set; }

        [JsonPropertyName("ProbabilityForSerializationOnly")]
        public string ProbabilityForSerializationOnly { get; set; } = string.Empty;

        [JsonPropertyName("ParameterSets")]
        public List<ParameterSet> ParameterSets { get; set; } = new();

        [JsonPropertyName("SettlementStatus")]
        public long SettlementStatus { get; set; }

        [JsonPropertyName("RankOrNull")]
        public SettlementFinishedForSerializationOnly RankOrNull { get; set; } = new();
    }
}
