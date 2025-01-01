using OpenQA.Selenium.DevTools.V129.HeadlessExperimental;

namespace playwright_newintegrationtests.PlaywrightCode
{
    [Binding]
    public class ClassRecordTest01 : PageTest
    {
        // [OneTimeSetUp]
        // public static async Task SetUpConfigAndRunner()
        // {
        //   This method sets up the configuration for running visual tests.
        //   The configuration is shared by all tests in a test suite, so it belongs in a `BeforeAll` method.
        //   If you have more than one test class, then you should abstract this configuration to avoid duplication.
        // }

        private readonly IPage _page;

        [SetUp]
        public async Task Setup()
        {
            RepeatableActions.ActionDriver();

            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            // Browser
            await using var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = Environment.GetEnvironmentVariable("HEADED") != "1"

                //  Headless = false  // display web pages
                //  Headless = true   // don't display web pages
            });

            await RepeatableMethods.LaunchLoginUser(Page, urlinfo.Testurlwebtc, userinfo.Testuserid, userinfo.Testuserpassword);
        }

        [Test]
        public async Task _1_1_UserLoginToTheWebTCFVTandlandonsearchpage()
        {
			if (Page.GetByText(pagehometab.text_esports, new() { Exact = true }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await RepeatablePlaywrightMethods.AccessLandingPage_GetByText(Page, pagehometab.text_esports).GetResult().ClickAsync(new() { Timeout = 10_000 });
                await Page.WaitForTimeoutAsync(2000);
                //  await RepeatablePlaywrightMethods.TestWaitForSelectorAsync(Page, elementsobjects.fixtureIDpath).GetResult().HoverAsync(new() { Timeout = 1_000 });
                await RepeatablePlaywrightMethods.TestButton_GetByRole(Page, pagehometab.text_home).GetResult().ClickAsync(new() { Timeout = 10_000 });
                await Page.WaitForTimeoutAsync(2000);
            }

            if (Page.GetByText(pagehometab.text_sports, new() { Exact = true }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await RepeatablePlaywrightMethods.TestElementExactTrue_GetByText(Page, pagehometab.text_sports).GetResult().ClickAsync(new() { Timeout = 10_000 });
                await Page.WaitForTimeoutAsync(2000);

                if (Page.GetByText(elementsobjects.fixturesid, new() { Exact = true }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
                {
                    await RepeatablePlaywrightMethods.TestTab_GetByRole(Page, elementsobjects.fixturesid).GetResult().HoverAsync(new() { Timeout = 10_000 });
                    await RepeatablePlaywrightMethods.TestButton_GetByRole(Page, pagehometab.text_home).GetResult().ClickAsync(new() { Timeout = 10_000 });
                    await Page.WaitForTimeoutAsync(2000);
                }
                else
                {
                    await Page.WaitForTimeoutAsync(2000);
                    PlaywrightUtils playwrightutils = new PlaywrightUtils();
                 // var playwrightmsg = playwrightutils.GetModuleDetails(MethodBase.GetCurrentMethod());
                    playwrightutils.TakeScreenShot(playwrightutils.GetModuleDetails(MethodBase.GetCurrentMethod()));
                    await Page.GoBackAsync();
                }
            }

            if (Page.GetByText(pagehometab.text_racing, new() { Exact = true }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await RepeatablePlaywrightMethods.TestElementExactTrue_GetByText(Page, pagehometab.text_racing).GetResult().ClickAsync(new() { Timeout = 10_000 });
                await Page.WaitForTimeoutAsync(2000);
                if (Page.GetByText(elementsobjects.fixturesid, new() { Exact = true }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
                {
                    await RepeatablePlaywrightMethods.TestElement_GetByText(Page, elementsobjects.fixturesid).GetResult().HoverAsync(new() { Timeout = 10_000 });
                    await RepeatablePlaywrightMethods.TestButton_GetByRole(Page, pagehometab.text_home).GetResult().ClickAsync(new() { Timeout = 10_000 });
                    await Page.WaitForTimeoutAsync(2000);
                }
                else
                {
                    await Page.WaitForTimeoutAsync(2000);
                    PlaywrightUtils playwrightutils = new PlaywrightUtils();
                    playwrightutils.TakeScreenShot(playwrightutils.GetModuleDetails(MethodBase.GetCurrentMethod()));
                    await Page.GoBackAsync();
                }
            }

            if (Page.GetByText(pagehometab.text_virtuals, new() { Exact = true }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
            {
                await RepeatablePlaywrightMethods.AccessLandingPage_GetByText(Page, pagehometab.text_virtualsports).GetResult().ClickAsync(new() { Timeout = 10_000 });
                await Page.WaitForTimeoutAsync(2000);
                if (Page.GetByText(elementsobjects.fixturesid, new() { Exact = true }).IsVisibleAsync(new() { Timeout = 10_000 }).Result)
                {
                    await RepeatablePlaywrightMethods.TestTab_GetByRole(Page, elementsobjects.fixturesid).GetResult().HoverAsync(new() { Timeout = 10_000 });
                    await RepeatablePlaywrightMethods.TestButton_GetByRole(Page, pagehometab.text_home).GetResult().ClickAsync(new() { Timeout = 10_000 });
                    await Page.WaitForTimeoutAsync(2000);
                }
                else
                {
                    await Page.WaitForTimeoutAsync(2000);
                    PlaywrightUtils playwrightutils = new PlaywrightUtils();
                    playwrightutils.TakeScreenShot(playwrightutils.GetModuleDetails(MethodBase.GetCurrentMethod()));
                    await Page.GoBackAsync();
                }
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            await RepeatablePlaywrightMethods.TesterSignOut(Page, @"ICEPOR\\t.f.vtos01");

            await RepeatablePlaywrightMethods.TestElement_GetByText(Page, userinfo.Domainuserid).GetResult().ClickAsync(new() { Timeout = 10_000 });
            await RepeatablePlaywrightMethods.TestElement_GetByText(Page, instructions.SIGNOUT).GetResult().ClickAsync(new() { Timeout = 10_000 });
            await RepeatablePlaywrightMethods.TestButton_GetByRole(Page, titles.yes).GetResult().ClickAsync(new() { Timeout = 10_000 });

            //await Page.GetByText(userinfo.Domainuserid).WaitForAsync();
            //await Page.GetByText(userinfo.Domainuserid).ClickAsync();
            //await Page.GetByText("Sign out").WaitForAsync();
            //await Page.GetByText("Sign out").ClickAsync();
            //await Page.GetByRole(AriaRole.Button, new() { Name = "Yes" }).WaitForAsync();
            //await Page.GetByRole(AriaRole.Button, new() { Name = "Yes" }).ClickAsync();

            await Page.CloseAsync();

            //await RepeatablePlaywrightMethods.TesterSignOut(Page, @"ICEPOR\\t.f.vtos01", instructions.click); 
            //await RepeatablePlaywrightMethods.TestButton_GetByRole(Page, "Yes", instructions.click);

            // Close Eyes to tell the server it should display the results.
            // Eyes.CloseAsync();

            // Close the page.


            // Warning: `eyes_.CloseAsync()` will NOT wait for visual checkpoints to complete.
            // You will need to check the Eyes Test Manager for visual results per checkpoint.
            // Note that "unresolved" and "failed" visual checkpoints will not cause the JUnit test to fail.

            // If you want the JUnit test to wait synchronously for all checkpoints to complete, then use `eyes_.Close()`.
            // If any checkpoints are unresolved or failed, then `eyes_.Close()` will make the JUnit test fail.
        }

        //[OneTimeTearDown]
        //public static void PrintResults()
        //{
        //    // Close the Playwright instance.
        //    Playwright.Dispose();

        //    // Close the batch and report visual differences to the console.
        //    // Note that it forces JUnit to wait synchronously for all visual checkpoints to complete.
        ////    TestResultsSummary allTestResults = Runner.GetAllTestResults();
        ////    TestContext.Out.WriteLine(allTestResults);
        //}
    }
}

