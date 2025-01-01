namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels
{
    public class GetFullFixtureRequest
    {
        [JsonPropertyName("IncludeFixture")]
        public bool IncludeFixture { get; set; } = true;

        [JsonPropertyName("IncludeFixtureParticipants")]
        public bool IncludeFixtureParticipants { get; set; } = false;

        [JsonPropertyName("IncludeOptionMarkets")]
        public bool IncludeOptionMarkets { get; set; } = false;

        [JsonPropertyName("OptionMarketQueryFilterOrNull")]
        public OptionMarketQueryFilter? OptionMarketQueryFilter { get; set; }
    }
}
