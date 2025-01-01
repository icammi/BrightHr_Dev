namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.OptionMarkets
{
    public class Fractional
    {
        [JsonPropertyName("Numerator")]
        public int Numerator { get; set; }

        [JsonPropertyName("Denominator")]
        public int Denominator { get; set; }
    }
}
