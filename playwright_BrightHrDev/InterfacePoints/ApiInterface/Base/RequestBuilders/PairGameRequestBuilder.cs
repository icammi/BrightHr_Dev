using playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.DataModels;

namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders
{
    public class PairGameRequestBuilder
    {
        private const string ExampleRequestFile = "CreatePairGameV3.json";

        private readonly IDataUtility _dataUtility;
        private PairGameRequest _pairGame = new();

        public PairGameRequestBuilder(IDataUtility dataUtility)
        {
            _dataUtility = dataUtility;
        }

        public PairGameRequestBuilder CreateAPairGame()
        {
            var exampleData = _dataUtility.GetJsonFileData(ExampleRequestFile);

            _pairGame = JsonSerializer.Deserialize<PairGameRequest>(exampleData) ?? new();
            _pairGame.StartDate = DateTime.Now.AddDays(1);
            _pairGame.CutOffDate = DateTime.Now.AddDays(1).AddMonths(1);

            return this;
        }

        public PairGameRequestBuilder WithCutOffDate(DateTime cutOffDate)
        {
            _pairGame.CutOffDate = cutOffDate;
            return this;
        }

        public PairGameRequestBuilder WithStartDate(DateTime startDate)
        {
            _pairGame.StartDate = startDate;
            return this;
        }

        public PairGameRequestBuilder WithCompetitionId(int competitionId)
        {
            _pairGame.CompetitionId = competitionId;
            return this;
        }

        public PairGameRequestBuilder WithHomeParticipant(int homeParticipantId)
        {
            _pairGame.HomeParticipantId = homeParticipantId;
            return this;
        }

        public PairGameRequestBuilder WithAwayParticipant(int awayParticipantId)
        {
            _pairGame.AwayParticipantId = awayParticipantId;
            return this;
        }

        public PairGameRequest Build()
        {
            return _pairGame;
        }
    }
}
