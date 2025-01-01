namespace playwright_newintegrationtests.InterfacePoints.DbInterface.SqlScripts
{
    public partial class Sql
    {
        public static string GetAttributeTypes => @"
            select
                [fId],
                [fName]
            from virtual.tabAttribute
        ";
    }
}
