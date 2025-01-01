namespace playwright_newintegrationtests.Base
{
    public class BasePage
    {
        private static IWebElement _webElement;
        private WebDriverFactory webDriverFactory;
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger(); // igc private

        public BasePage(WebDriverFactory driver)
        {
            this.webDriverFactory = driver;
        }
        public IWebElement WaitTillElementExist(string locator, ElementLocator elementLocatorType = ElementLocator.Xpath, int TimeOutForFindingElement = 10)
        {
            try  // igc
            {
                var wait = new WebDriverWait(webDriverFactory.Browser, TimeSpan.FromSeconds(TimeOutForFindingElement));

                switch (elementLocatorType)
                {
                    case ElementLocator.Xpath: { _webElement = wait.Until(ExpectedConditions.ElementExists(By.XPath(locator))); break; }
                    case ElementLocator.PartialLinkText: { _webElement = wait.Until(ExpectedConditions.ElementExists(By.PartialLinkText(locator))); break; }
                    case ElementLocator.Name: { _webElement = wait.Until(ExpectedConditions.ElementExists(By.Name(locator))); break; }
                    case ElementLocator.LinkText: { _webElement = wait.Until(ExpectedConditions.ElementExists(By.LinkText(locator))); break; }
                    case ElementLocator.ID: { _webElement = wait.Until(ExpectedConditions.ElementExists(By.Id(locator))); break; }
                    case ElementLocator.CssSelector: { _webElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector(locator))); break; }
                    case ElementLocator.TagName: { _webElement = wait.Until(ExpectedConditions.ElementExists(By.TagName(locator))); break; }
                    case ElementLocator.ClassName: { _webElement = wait.Until(ExpectedConditions.ElementExists(By.ClassName(locator))); break; }
                    default: { _webElement = null; _webElement.Should().NotBeNull("Invalid elementLocatorType: " + elementLocatorType); break; }
                }
                return _webElement;
            }
            catch (Exception Ex)
            {
                _logger.Info("WaitTillElementExist: ");
                _logger.Info("elementLocatorType:" + elementLocatorType);
                _logger.Info(Ex.Message.ToString());
                return null;
            }
        }

        /// Create a instance of Selenium webElement
        public IWebElement WaitTillElementDisplayed(string locator, ElementLocator elementLocatorType = ElementLocator.Xpath, int TimeOutForFindingElement = 10)
        {
            try // igc
            {
                var wait = new WebDriverWait(webDriverFactory.Browser, TimeSpan.FromSeconds(TimeOutForFindingElement));

                switch (elementLocatorType)
                {
                    case ElementLocator.Xpath: { _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator))); break; }
                    case ElementLocator.PartialLinkText: { _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locator))); break; }
                    case ElementLocator.Name: { _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locator))); break; }
                    case ElementLocator.LinkText: { _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locator))); break; }
                    case ElementLocator.ID: { _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locator))); break; }
                    case ElementLocator.CssSelector: { _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locator))); break; }
                    case ElementLocator.TagName: { _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locator))); break; }
                    case ElementLocator.ClassName: { _webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locator))); break; }
                    default: { _webElement = null; _webElement.Should().NotBeNull("Invalid elementLocatorType: " + elementLocatorType); break; }
                }
                return _webElement;
            }
            catch (Exception Ex)
            {
                _logger.Info("WaitTillElementDisplayed: ");
                _logger.Info("elementLocatorType:" + elementLocatorType);
                _logger.Info(Ex.Message.ToString());
                return null;
            }
        }

        /// Create a instance of Selenium webElement when element staleness is gone 
        public void WaitTillElementStalenessOf(string locator, ElementLocator elementLocatorType = ElementLocator.Xpath, int TimeOutForFindingElement = 10)
        {
            try // igc
            {
                var wait = new WebDriverWait(webDriverFactory.Browser, TimeSpan.FromSeconds(TimeOutForFindingElement));

                switch (elementLocatorType)
                {
                    case ElementLocator.Xpath: { wait.Until(ExpectedConditions.StalenessOf(webDriverFactory.Browser.FindElement(By.XPath(locator)))); break; }
                    case ElementLocator.PartialLinkText: { wait.Until(ExpectedConditions.StalenessOf(webDriverFactory.Browser.FindElement(By.PartialLinkText(locator)))); break; }
                    case ElementLocator.Name: { wait.Until(ExpectedConditions.StalenessOf(webDriverFactory.Browser.FindElement(By.Name(locator)))); break; }
                    case ElementLocator.LinkText: { wait.Until(ExpectedConditions.StalenessOf(webDriverFactory.Browser.FindElement(By.LinkText(locator)))); break; }
                    case ElementLocator.ID: { wait.Until(ExpectedConditions.StalenessOf(webDriverFactory.Browser.FindElement(By.Id(locator)))); break; }
                    case ElementLocator.CssSelector: { wait.Until(ExpectedConditions.StalenessOf(webDriverFactory.Browser.FindElement(By.CssSelector(locator)))); break; }
                    case ElementLocator.TagName: { wait.Until(ExpectedConditions.StalenessOf(webDriverFactory.Browser.FindElement(By.TagName(locator)))); break; }
                    case ElementLocator.ClassName: { wait.Until(ExpectedConditions.StalenessOf(webDriverFactory.Browser.FindElement(By.ClassName(locator)))); break; }
                    default: { _webElement = null; _webElement.Should().NotBeNull("Invalid elementLocatorType: " + elementLocatorType); break; }
                }
            }
            catch (Exception Ex)
            {
                _logger.Info("WaitTillElementStalenessOf: ");
                _logger.Info("elementLocatorType:" + elementLocatorType);
                _logger.Info(Ex.Message.ToString());
            }
        }
    }
}

