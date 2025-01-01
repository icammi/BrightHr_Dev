namespace playwright_newintegrationtests.PlaywrightCode
{
    public class DateTimePlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://webtc.ait.env.works/");
            // SetDefaultExpectTimeout(10000);

            var datetime = DateTime.Now.ToUniversalTime();
            var datetimes = DateTime.Now.ToUniversalTime();

            var dateadd28 = DateTime.Now.ToUniversalTime().AddDays(28);
            var datedminus7 = DateTime.Now.ToUniversalTime().AddDays(-7);
        }
    }
}
