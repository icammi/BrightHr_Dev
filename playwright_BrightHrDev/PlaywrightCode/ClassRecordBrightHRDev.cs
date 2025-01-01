using static ClassConfiguration.Config;

namespace playwright_newintegrationtests.PlaywrightCode
{
    [Binding]
    public class ClassRecordBrightHRDev : PageTest
    {
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
            });

            await RepeatableMethods.LaunchLoginUserBrightHr(Page, urlinfo.TesturlbrighthrSandbox, userinfo.Testuserid, userinfo.Testuserpassword);

            /// Login
            /// 
            await RepeatablePlaywrightMethods.TestTextBox_GetByLabel(Page, BrightHr_obj_pageLogin.text_email).GetResult().FillAsync(userinfo.Testuserid);
            await RepeatablePlaywrightMethods.TestTextBox_GetByLabel(Page, BrightHr_obj_pageLogin.text_password).GetResult().FillAsync(userinfo.Testuserpassword);
            await RepeatablePlaywrightMethods.TestButton_GetByRole(Page, "Login").GetResult().ClickAsync();
        }

        [Test]
        public async Task _0_1_UserLoginToTheBrightHrlandonsearchpage()
        {
            /// display links

            /// Employees Hub

            await RepeatablePlaywrightMethods.TestLink_GetByRole(Page, "See all employees").GetResult().ClickAsync().WaitAsync(TimeSpan.FromMinutes(waittimevalues.waittimemins));   await Page.WaitForTimeoutAsync(2000);

            await Page.Locator("#main-content").GetByRole(AriaRole.Link, new() { Name = "Employees" }).ClickAsync();    await Page.WaitForTimeoutAsync(2000);

            /// Display Employee details

            await Page.GetByTestId("EditButton").First.ClickAsync().WaitAsync(TimeSpan.FromMilliseconds(waittimevalues.waittimemilliliseconds));    await Page.WaitForTimeoutAsync(2000);
            await Page.GetByTestId("sideBar").GetByRole(AriaRole.Link, new() { Name = "Employees" }).ClickAsync();                                  await Page.WaitForTimeoutAsync(2000);
            await Page.GetByTestId("EditButton").Nth(1).ClickAsync().WaitAsync(TimeSpan.FromMilliseconds(waittimevalues.waittimemilliliseconds));   await Page.WaitForTimeoutAsync(2000);
            await Page.GetByTestId("sideBar").GetByRole(AriaRole.Link, new() { Name = "Employees" }).ClickAsync();                                  await Page.WaitForTimeoutAsync(2000);
            await Page.GetByTestId("EditButton").Nth(2).ClickAsync().WaitAsync(TimeSpan.FromMilliseconds(waittimevalues.waittimemilliliseconds));   await Page.WaitForTimeoutAsync(2000);
            await Page.GetByTestId("sideBar").GetByRole(AriaRole.Link, new() { Name = "Employees" }).ClickAsync();                                  await Page.WaitForTimeoutAsync(2000);
        }

        [TearDown]
        public async Task TearDown()
        {
            await Page.GetByRole(AriaRole.Link, new() { Name = "Logout" }).ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });

            await Page.CloseAsync();
        }
    }
}

