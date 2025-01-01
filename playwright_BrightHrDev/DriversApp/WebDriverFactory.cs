namespace playwright_newintegrationtests.DriversApp
{
    public class WebDriverFactory
    {
        private IConfigurationRoot _configurationRoot;
        private static WebDriverWait _browserWait;
        private  IWebDriver _browser;

        public WebDriverFactory(IConfigurationRoot configurationRoot)
        {
            this._configurationRoot = configurationRoot;
            //_browser ??= GetDriver();
        }
        public IWebDriver GetDriver()
        {
            IConfigurationRoot configuration = _configurationRoot;
            var browserConfig = configuration.GetSection("WebTC").Get<WebTcConfig>()
                ?? throw new InvalidOperationException("WebTC config was not set.");

            switch (browserConfig.Browser)
            {
                case "chrome":
                    {
                        ChromeOptions chrome = new ();

                        if (browserConfig.Headless)
                        {
                            chrome.AddArgument("headless");
                            chrome.AddArguments("--window-size=1920,1200");
                        }

                        chrome.AddArgument("start-maximized");
                        chrome.AddArgument("disable-gpu");
                        chrome.AddArgument("disable-dev-shm-usage");
                        chrome.AddArgument("ignore-certificate-errors");
                        _browser = new ChromeDriver(chrome);
                        break;
                    }
                case "firefox":
                    {
                        _browser = new FirefoxDriver();
                        break;
                    }
                default:
                    {
                        _browser = new ChromeDriver();
                        break;
                    }
            }

            return _browser;
        }

        public void GoToWebTc()
        {
         //   var webTcUrl = AESOperation.Decrypted(_configurationRoot.GetValue<string>($"WebTC:CryptionKey"), _configurationRoot.GetValue<String>($"WebTC:WebTcUrl"));

           // _browser.Navigate().GoToUrl(webTcUrl);
        }

        public IWebDriver Browser
        {
            get
            {
                if (_browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return _browser;
            }
            set
            {
                _browser = value;
            }
        }
        public WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return _browserWait;
            }
            private set
            {
                _browserWait = value;
            }
        }

        //  Stops & Quits current WebDriver instance
        public void StopBrowser()
        {

            _browser.Quit();
            Browser = null;
            BrowserWait = null;
        }
        
        public static void WaitDriverReady(IWebDriver _driver)
        {
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            Thread.Sleep(3000);
        }

        public static void WaitDriverRefresh(IWebDriver _driver)
        {
            WaitDriverReady(_driver);
            _driver.Navigate().Refresh();
            WaitDriverReady(_driver);
            Thread.Sleep(3000);
        }
    }
}
