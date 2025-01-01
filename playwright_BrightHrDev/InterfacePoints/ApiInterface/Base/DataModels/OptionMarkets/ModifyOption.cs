namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.OptionMarkets;

public class ModifyOption
{
    [JsonPropertyName("OptionId")]
    [SqlDataField("fId")]
    public long OptionId { get; set; }

    [JsonIgnore]
    [SqlDataField("frOptionMarketId")]
    public long OptionMarketId { get; set; }

    [JsonPropertyName("ResultStatus")]
    [SqlDataField("frResultStatusId")]
    public string ResultStatus { get; set; }
}