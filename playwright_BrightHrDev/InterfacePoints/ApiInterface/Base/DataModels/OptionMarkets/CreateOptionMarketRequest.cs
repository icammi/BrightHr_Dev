namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.OptionMarkets
{
    public class CreateOptionMarketRequest
    {
        [JsonPropertyName("OptionMarketTemplateId")]
        public long OptionMarketTemplateId { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Options")]
        public List<CreateOption> Options { get; set; } = new();

        [JsonPropertyName("Parameters")]
        public List<Parameter> Parameters { get; set; } = new();

        [JsonPropertyName("TotalMarketTemplateProbability")]
        public int? TotalMarketTemplateProbability { get; set; }

        [JsonPropertyName("TotalMarketTemplateProbabilityForSerializationOnly")]
        public string TotalMarketTemplateProbabilityForSerializationOnly { get; set; } = string.Empty;

        [JsonPropertyName("ProbabilityCoverage")]
        public int? ProbabilityCoverage { get; set; }

        [JsonPropertyName("OptionMarketSpecials")]
        public int? OptionMarketSpecials { get; set; } = 0;
    }
}
