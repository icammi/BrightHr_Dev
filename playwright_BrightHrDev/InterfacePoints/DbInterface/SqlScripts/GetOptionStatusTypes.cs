namespace playwright_newintegrationtests.InterfacePoints.DbInterface.SqlScripts
{
    public partial class Sql
    {
        public static string GetOptionStatusTypes => @"
            select
                [fId],
                [fName]
            from virtual.tabOptionStatus
        ";
    }
}
