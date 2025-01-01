namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels.Fixture
{
    public class Team
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }

        [JsonPropertyName("ParticipantId")]
        public long ParticipantId { get; set; }

        [JsonPropertyName("NameId")]
        public long NameId { get; set; }

        [JsonPropertyName("Status")]
        public long Status { get; set; }

        [JsonPropertyName("IsUnnamedFavorite")]
        public bool IsUnnamedFavorite { get; set; }

        [JsonPropertyName("SequenceNumber")]
        public long SequenceNumber { get; set; }

        [JsonPropertyName("ParticipantType")]
        public long ParticipantType { get; set; }
    }
}
