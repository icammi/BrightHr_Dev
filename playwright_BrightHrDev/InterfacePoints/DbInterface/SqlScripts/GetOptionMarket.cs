namespace playwright_newintegrationtests.InterfacePoints.DbInterface.SqlScripts
{
    public partial class Sql
    {
        public static string GetOptionMarket => @"
            select
                [fId],
                [fName]
            from virtual.tabOptionMarket
            where [frFixtureId] = @FixtureId
        ";
    }
}