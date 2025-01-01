namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels
{
    public class PairGameRequest
    {
        [JsonPropertyName("StartDate")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [JsonPropertyName("StartDateUnixForSerializationOnly")]
        public long StartDateUnix { get; set; }

        [JsonPropertyName("CutOffDate")]
        public DateTime CutOffDate { get; set; } = DateTime.Now;

        [JsonPropertyName("CutOffDateUnixForSerializationOnly")]
        public long CutOffDateUnix { get; set; }

        [JsonPropertyName("RegionId")]
        public int RegionId { get; set; }

        [JsonPropertyName("CompetitionId")]
        public int CompetitionId { get; set; }

        [JsonPropertyName("HomeParticipantId")]
        public int HomeParticipantId { get; set; }

        [JsonPropertyName("AwayParticipantId")]
        public int AwayParticipantId { get; set; }

        [JsonPropertyName("CountryId")]
        public int CountryId { get; set; }
    }
}
