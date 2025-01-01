namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public class FixtureData
    {
        [SqlDataField("fId")]
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [SqlDataField("frName")]
        [JsonPropertyName("NameId")]
        public long NameId { get; set; }

        [SqlDataField("frStatusId")]
        [JsonPropertyName("Status")]
        public long Status { get; set; }

        [SqlDataField("fStartDate")]
        [JsonPropertyName("StartDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonPropertyName("StartDateUtc")]
        public long StartDateUtc { get; set; }

        [SqlDataField("fCutOffDate")]
        [JsonPropertyName("CutOffDate")]
        public DateTimeOffset CutOffDate { get; set; }

        [JsonPropertyName("CutOffDateUtc")]
        public long CutOffDateUtc { get; set; }

        [JsonPropertyName("CompetitionId")]
        public long CompetitionId { get; set; }

        [SqlDataField("fSequenceNumber")]
        [JsonPropertyName("SequenceNumber")]
        public long SequenceNumber { get; set; }

        [SqlDataField("fIsSuspended")]
        [JsonPropertyName("IsSuspended")]
        public bool IsSuspended { get; set; }

        [JsonPropertyName("CountryId")]
        public long CountryId { get; set; }

        [JsonPropertyName("IsPlannedInPlay")]
        public bool IsPlannedInPlay { get; set; }
    }
}
