using Microsoft.AspNetCore.Mvc.RazorPages;

namespace playwright_newintegrationtests.PlaywrightCode
{
    public class RepeatableMethods : PageTest
    {
        //// Runner Settings.
        //// These could be set by environment variables or other input mechanisms.
        //// They are hard-coded here to keep the example project simple.
        //private static readonly bool UseUltrafastGrid = true;

        //// Test control inputs to read once and share for all tests
        //private static string? ApplitoolsApiKey;
        //private static bool Headless;

        //// Test-specific objects
        //private static IPlaywright Playwright;
        //private static IBrowser Browser;
        //private IBrowserContext Context;
        //private IPage Page;
        //// private Eyes Eyes;

        public static async Task DatetimeAction(IPage Page, DateTime actiontimepicker, string actionpath)
        {
            var dateFormat = string.Format("dd/MMMM/yyyy hh:mm:ss tt");

            var timeFormathh = string.Format("hh");
            var timeFormatmm = string.Format("mm");
            var timeFormatss = string.Format("ss");

            var timeFormattt = string.Format("tt");

            if (actiontimepicker.ToString(timeFormathh) == "12") { await Page.Locator(actionpath).Nth(0).ClickAsync(); }
            else { await Page.Locator(actionpath).Nth(Convert.ToInt16(actiontimepicker.ToString(timeFormathh))).ClickAsync(); }
            await Page.WaitForTimeoutAsync(1000);

            await Page.Locator(actionpath).Nth(Convert.ToInt16(Convert.ToInt16(actiontimepicker.ToString(timeFormatmm)) + 12)).ClickAsync();
            await Page.WaitForTimeoutAsync(1000);

            await Page.Locator(actionpath).Nth(Convert.ToInt16(Convert.ToInt16(actiontimepicker.ToString(timeFormatss)) + 72)).ClickAsync();
            await Page.WaitForTimeoutAsync(1000);

            if (actiontimepicker.ToString(timeFormattt) == "AM") { await Page.Locator(actionpath).Nth(132).ClickAsync(); }
            else { await Page.Locator(actionpath).Nth(133).ClickAsync(); }
        }

        public static async Task TakeScreenShot(IPage Page, string filename)
        {
            filename = filename + " " + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".png";
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "screenshot/" + filename,
                FullPage = true
            });
        }

        public static async Task LaunchLoginUserBrightHr(IPage Page, string userbrowser, string userdid, string userpassword)
        {
            // This method sets up each test with its own Page
            //var browser = await Microsoft.Playwright.Playwright.CreateAsync();

            await Page.GotoAsync(userbrowser);


        }

        public static async Task LaunchLoginUser(IPage Page, string userbrowser, string userdid, string userpassword)
        {
             /// Login

            await RepeatablePlaywrightMethods.TestTextBox_GetByLabel(Page, BrightHr_obj_pageLogin.text_email).GetResult().FillAsync(userdid);
            await RepeatablePlaywrightMethods.TestTextBox_GetByLabel(Page, BrightHr_obj_pageLogin.text_password).GetResult().FillAsync(userpassword);
            await RepeatablePlaywrightMethods.TestButton_GetByRole(Page, "Login").GetResult().ClickAsync();
            await Page.WaitForTimeoutAsync(2000);
        }


        public static async Task VideoBrowserPage(IPage Page, string userbrowser)
        {
            //    Playwright playwright = new();

            //    using var playwright = await Playwright.CreateAsync();
            //    await using var browser = await playwright.Chromium.LaunchAsync();

            //    //In your Browser context set viewport size to null so that it will set to maximum size as per your screen size. 
            //    var context = await browser.NewContextAsync(new BrowserNewContextOptions
            //    {
            //        // Set viewport size to null for maximum size
            //        ViewportSize = null
            //    });


            var contextvid = await Page.Context.Browser.NewContextAsync(new()
            {
                RecordVideoDir = "videos/"
            });
            // Make sure to close, so that videos are saved.
            await Page.Context.CloseAsync();



            //   var page = await Page.Context.NewPageAsync();

            //   // Navigate to your desired URL
            //   await page.GotoAsync("https://example.com");

            //   // You can also set a specific size if needed
            //   await page.SetViewportSizeAsync(1280, 720);

            //   // Perform your tests...

            //   //Playwright playwright = Playwright.create();

            ////   Browser browserContext browserContext = await page...Context.Browser.NewContextAsync(new BrowserNewContextOptions().set.setrecordVideoDir(Paths.get("myvideos")));

            //   //Page page = browserContext.newPage();

            //   var context = await Page.Context.Browser.NewContextAsync(new() { RecordVideoDir = "videos/" });

            //   //// Make sure to close, so that videos are saved.
            //   await Page.Context.CloseAsync();
        }
    }
}

