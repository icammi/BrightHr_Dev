namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class OptionPriceContext
    {
        [JsonPropertyName("LoginDomainId")]
        public SettlementFinishedForSerializationOnly LoginDomainId { get; set; } = new();

        [JsonPropertyName("CountryId")]
        public SettlementFinishedForSerializationOnly CountryId { get; set; } = new();

        [JsonPropertyName("Tier")]
        public SettlementFinishedForSerializationOnly Tier { get; set; } = new();

        [JsonPropertyName("IsPriceBoost")]
        public bool IsPriceBoost { get; set; }
    }
}
