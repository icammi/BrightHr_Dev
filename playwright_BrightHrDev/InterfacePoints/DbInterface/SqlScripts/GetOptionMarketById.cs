namespace playwright_newintegrationtests.InterfacePoints.DbInterface.SqlScripts
{
    public partial class Sql
    {
        public static string GetOptionMarketById => @"
            select
                [fId],
                [frOptionMarketId],
                [frResultStatusId]
            from [virtual].[tabOption]
            where [frOptionMarketId] = @OptionMarketId
            and [fId] = @OptionId
        ";
    }
}
