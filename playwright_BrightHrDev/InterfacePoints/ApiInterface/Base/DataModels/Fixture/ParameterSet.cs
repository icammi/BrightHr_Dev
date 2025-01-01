namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public partial class ParameterSet
    {
        [JsonPropertyName("Index")]
        public long Index { get; set; }

        [JsonPropertyName("Parameters")]
        public List<Parameter> Parameters { get; set; } = new();
    }
}
