using System.Diagnostics;
using Microsoft.Playwright;

namespace playwright_newintegrationtests.DriversApp
{
    public class Driver : IDisposable, IDriver
    {
        private IBrowser? _browser;
        public Driver()
        {
        }
        public IPage Page { get; set; }


        public async Task<IPage> InitializePlaywright()
        {
            try
            {
                var playwright = await Playwright.CreateAsync();
                _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                //  Headless = true
                    Headless = false
                });

                var ctx = await _browser.NewContextAsync(new() { IgnoreHTTPSErrors = true });

                this.Page = await ctx.NewPageAsync();
                return this.Page;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
        public void Dispose() => _browser?.CloseAsync();
    }
}