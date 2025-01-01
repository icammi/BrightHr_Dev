namespace playwright_newintegrationtests.Utilities
{
    public class WebUtils
    {
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly WebDriverFactory driver;

        public WebUtils(WebDriverFactory driver)
        {
            this.driver = driver;
        }

        // Captures Screenshot to specified filename
        public string TakeScreenShot(string filename)
        {
            string rootpath = Directory.GetCurrentDirectory();
            string pathString = System.IO.Path.Combine(rootpath, "ScreenShots");
            System.IO.DirectoryInfo ScreenShotdir = new (pathString);

            if (!ScreenShotdir.Exists)
                System.IO.Directory.CreateDirectory(pathString);

            var screen = driver.Browser.TakeScreenshot();
            filename = filename + " " + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
            filename = Path.Combine(pathString, filename);
            screen.SaveAsFile(filename);

            return filename;
        }

        // ElementExists(By.Id(id));

        public bool ElementExists(By method)
        {
            var oldTime = driver.Browser.Manage().Timeouts().ImplicitWait;
            driver.Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1);
            try
            {
                bool isElementDisplayed = driver.Browser.FindElement(method).Displayed;
                driver.Browser.Manage().Timeouts().ImplicitWait = oldTime;
                return true;
            }
            catch
            {
                driver.Browser.Manage().Timeouts().ImplicitWait = oldTime;
                return false;
            }
        }

        public string NLOGMessage(string nlogtype, string nlogmessage)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToTitleCase(nlogtype);

            //var msg = new LogEventInfo(LogLevel.Info, string.Empty, "this is an error message");
            //msg.Properties.Add("User", "Tester");
            //_logger.Info(nlogmessage);

            //_logger.Info()
            //    .Message("This is a message")
            //    .Property("User", "Test Automation")
            //    .Write();

            switch (nlogtype.ToUpper())
            {
                case "FATAL": { _logger.Debug(nlogmessage, "Automation", DateTime.Now); break; }
                case "ERROR": { _logger.Error(new Exception(), nlogmessage, DateTime.Now); break; }
                case "WARN": { _logger.Warn(nlogmessage, DateTime.Now); break; }
                case "INFO": { _logger.Info("This is a message from {0}", "Test Automation"); break; }
                case "DEBUG": { _logger.Debug(nlogmessage); break; }
                case "TRACE": { _logger.Trace(nlogmessage); break; }

                default: { _logger.Info("This is an invalid logtype :" + nlogtype, "Test Automation"); break; }
            }

            return nlogmessage;
        }
    }
}
