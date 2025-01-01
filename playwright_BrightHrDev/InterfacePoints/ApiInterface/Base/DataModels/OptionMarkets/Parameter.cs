namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.OptionMarkets
{
    public class Parameter
    {
        [JsonPropertyName("Index")]
        public int Index { get; set; }

        [JsonPropertyName("Parameters")]
        public List<Parameter> Parameters { get; set; } = new();

        [JsonPropertyName("ParameterKey")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("IsEmpty")]
        public bool IsEmpty { get; set; }

        [JsonPropertyName("Value")]
        public string ValueAsString { get; set; } = string.Empty;
    }
}
