namespace playwright_newintegrationtests.InterfacePoints.DbInterface.SqlScripts
{
    public partial class Sql
    {
        public static string GetParticipantStatusTypes => @"
            select
                [fId],
                [fName]
            from Virtual.tabFixtureParticipantStatus
        ";
    }
}
