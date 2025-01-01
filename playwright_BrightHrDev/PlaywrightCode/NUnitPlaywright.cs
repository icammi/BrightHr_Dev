namespace playwright_newintegrationtests.PlaywrightCode
{
    public class NUnitPlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("http://www.eaapp.somee.com");
            // SetDefaultExpectTimeout(10000);
        }

        [Test]
        public async Task NUnitPlaywrightTest1()
        {
            await Page.Locator("text='Login'").HighlightAsync();//.WaitAsync();
            var lnkLogin = Page.Locator("text='Login'");//.WaitAsync();
            await lnkLogin.ClickAsync();

            // var btnLogin = Page.Locator("input", new PageLocatorOptions { HasTextString = "Log in" }); 
            // await Page.ClickAsync("text='Login'");
            // await btnLogin.ClickAsync();

            await Page.FillAsync("#UserName", "admin");
            await Page.FillAsync("#Password", "password");
            await Page.ClickAsync("text=Log in");

            await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
        }
    }
}
