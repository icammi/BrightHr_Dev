namespace playwright_newintegrationtests.PlaywrightCode
{
    public class ClassUnitTests
    {
        [SetUp]
        public void Setup()
        {
            //Playwright
            //using var playwright = await Playwright.CreateAsync();
        }

        [Test]
        public async Task ClassUnitTest1()
        {
            // Playwright
            using var playwright = await Playwright.CreateAsync();

            // Browser
            await using var browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = Environment.GetEnvironmentVariable("HEADED") != "1"

                    //  Headless = false  // display pages
                    //  Headless = true   // display pages

                    // ,Args = clone.Args;
                    // ,Channel = clone.Channel;
                    // ,ChromiumSandbox = clone.ChromiumSandbox;
                    // ,Devtools = clone.Devtools;
                    // ,DownloadsPath = clone.DownloadsPath;
                    // ,Env = clone.Env;
                    // ,ExecutablePath = clone.ExecutablePath;
                    // ,FirefoxUserPrefs = clone.FirefoxUserPrefs;
                    // ,HandleSIGHUP = clone.HandleSIGHUP;
                    // ,HandleSIGINT = clone.HandleSIGINT;
                    // ,HandleSIGTERM = clone.HandleSIGTERM;
                    // ,Headless = clone.Headless;
                    // ,IgnoreAllDefaultArgs = clone.IgnoreAllDefaultArgs;
                    // ,IgnoreDefaultArgs = clone.IgnoreDefaultArgs;
                    // ,Proxy = clone.Proxy;
                    // ,SlowMo = clone.SlowMo;
                    // ,Timeout = clone.Timeout;
                    // ,TracesDir = clone.TracesDir;
                });

            // Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://www.eaapp.somee.com");
            await page.Locator("text='Login'").HighlightAsync();//.WaitAsync();
            await page.ClickAsync("text='Login'");

            // Take Screenshot image Login page   
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "EAApp.jpg"      // C:\Repos\playwright_newintegrationtests\playwright_newintegrationtests\bin\Debug\net8.0
										// Path = "./EAApp.png"    // C:\Repos\playwright_newintegrationtests\playwright_newintegrationtests\bin\Debug\net8.0
			});

            // await page.Locator("#UserName=admin").HighlightAsync();
            await page.FillAsync("#UserName", "admin");
            await page.FillAsync("#Password", "password");
            await page.ClickAsync("text=Log in");

            var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
            if (isExist)
            {
                await page.Locator("text='Employee Details'").HighlightAsync();
                await page.Locator("text='Employee Details'").ClickAsync();
            }
            else { isExist.Should().Be(true); }
;
        }
    }
}
