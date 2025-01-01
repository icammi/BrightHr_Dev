namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels
{
    public class GetFullFixtureResponse
    {
        [JsonPropertyName("HomeTeamOrNull")]
        public Team? HomeTeamOrNull { get; set; }

        [JsonPropertyName("AwayTeamOrNull")]
        public Team? AwayTeamOrNull { get; set; }

        [JsonPropertyName("FixtureDataOrNull")]
        public FixtureData? FixtureDataOrNull { get; set; }

        [JsonPropertyName("OptionMarkets")]
        public List<OptionMarket> OptionMarkets { get; set; } = new List<OptionMarket>();
    }
}
