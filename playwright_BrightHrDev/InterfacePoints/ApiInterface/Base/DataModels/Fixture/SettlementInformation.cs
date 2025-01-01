namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class SettlementInformation
    {
        [JsonPropertyName("SettlementStatus")]
        public long SettlementStatus { get; set; }

        [JsonPropertyName("SettlementTriggered")]
        public DateTimeOffset SettlementTriggered { get; set; }

        [JsonPropertyName("SettlementTriggeredForSerializationOnly")]
        public SettlementFinishedForSerializationOnly SettlementTriggeredForSerializationOnly { get; set; } = new();

        [JsonPropertyName("SettlementFinished")]
        public DateTimeOffset SettlementFinished { get; set; }

        [JsonPropertyName("SettlementFinishedForSerializationOnly")]
        public SettlementFinishedForSerializationOnly SettlementFinishedForSerializationOnly { get; set; } = new();

        [JsonPropertyName("SettlementStatusDescriptionOrNull")]
        public string SettlementStatusDescriptionOrNull { get; set; } = string.Empty;

        [JsonPropertyName("DeadHeatDivisor")]
        public long DeadHeatDivisor { get; set; }

        [JsonPropertyName("DeadHeatDivisorForSerialization")]
        public string DeadHeatDivisorForSerialization { get; set; } = string.Empty;

        [JsonPropertyName("HasSuccessfullySettledPreviously")]
        public bool HasSuccessfullySettledPreviously { get; set; }
    }
}
