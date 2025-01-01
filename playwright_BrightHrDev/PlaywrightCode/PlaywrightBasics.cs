using playwright_newintegrationtests.Pages;

namespace playwright_newintegrationtests.PlaywrightCode;

public class Tests
{
    [SetUp]
    public async Task Setup()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

    }

    [Test]
    public async Task Test1()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "EAApp.jpg"
        });
        await page.FillAsync("#UserName", "admin");
        await page.FillAsync("#Password", "password");
        await page.ClickAsync("text=Log in");
        var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
        isExist.Should().BeTrue();
    }

    [Test]
    public async Task TestWithPOM()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");

        var loginPage = new LoginPageUpgraded(page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");
        var isExist = await loginPage.IsEmployeeDetailsExists();
        isExist.Should().BeTrue();
    }


    [Test]
    public async Task TestNetwork()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");

        var loginPage = new LoginPageUpgraded(page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");

        //Wait for response - Way 1
        var waitResponse = page.WaitForResponseAsync("**/Employee");
        //while the button is clicked
        await loginPage.ClickEmployeeList();
        //give the response details
        var getResponse = await waitResponse;

        //Way 2 - Wait for response
        var response = await page.RunAndWaitForResponseAsync(async () => { await loginPage.ClickEmployeeList(); },
            x => x.Url.Contains("/Employee") && x.Status == 200);

        var isExist = await loginPage.IsEmployeeDetailsExists();
        isExist.Should().BeTrue();
    }

    [Test]
    public async Task? FlipkartNetworkInterception()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
        page.Response += (_, response) => Console.WriteLine(response.Status + "---" + response.Url);

        await page.RouteAsync("**/*", async route =>
        {
            if (route.Request.ResourceType == "image")
                await route.AbortAsync();
            else
                await route.ContinueAsync();
        });

        await page.GotoAsync("https://www.flipkart.com/", new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });
    }

    [Test]
    public async Task TestRecord01()
    {

    }
}