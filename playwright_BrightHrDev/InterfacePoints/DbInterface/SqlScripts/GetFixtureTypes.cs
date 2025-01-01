namespace playwright_newintegrationtests.InterfacePoints.DbInterface.SqlScripts
{
    public partial class Sql
    {
        public static string GetFixtureTypes => @"
            select
                [fId],
                [fName]
            from virtual.tabFixturetype
        ";
    }
}
