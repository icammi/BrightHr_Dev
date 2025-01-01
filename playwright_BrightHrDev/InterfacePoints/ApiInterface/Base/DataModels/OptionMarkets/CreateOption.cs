namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.OptionMarkets
{
    public class CreateOption
    {

        [JsonPropertyName("OptionTemplateId")]
        public long OptionTemplateId { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("PriceOrNull")]
        public Price? PriceOrNull { get; set; } = null;

        [JsonPropertyName("Parameters")]
        public List<Parameter> Parameters { get; set; } = new();

        [JsonPropertyName("FiftyFiftyMargin")]
        public float FiftyFiftyMargin { get; set; }

        [JsonPropertyName("FiftyFiftyMarginForSerializationOnly")]
        public string FiftyFiftyMarginForSerializationOnly { get; set; } = string.Empty;

        [JsonPropertyName("SortOrder")]
        public int SortOrder { get; set; }
    }
}
