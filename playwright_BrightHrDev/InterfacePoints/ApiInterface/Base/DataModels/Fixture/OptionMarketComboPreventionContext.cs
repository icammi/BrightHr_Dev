namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class OptionMarketComboPreventionContext
    {
        [JsonPropertyName("LoginDomainId")]
        public SettlementFinishedForSerializationOnly LoginDomainId { get; set; } = new();

        [JsonPropertyName("CountryId")]
        public SettlementFinishedForSerializationOnly CountryId { get; set; } = new();
    }
}
