using System.Collections.ObjectModel;

namespace playwright_newintegrationtests.UIHelper
{
    public class SeleniumHelper
    {
        private static IWebDriver driver;
        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }
        public static void ClickButton(By buttonElement)
        {
            var button = driver.FindElement(buttonElement);
            button.Click();
        }

        public static string GetTitle()
        {
            return driver.Title;
        }

        public static string GetUrl()
        {
            return driver.Url;
        }

        public static void SwitchToWindow(string tabName)
        {
            var currentTab = driver.CurrentWindowHandle;
            ReadOnlyCollection<string> allTabs = driver.WindowHandles;
            foreach (var tab in allTabs)
            {
                if (tab.Contains(tabName))
                {
                    driver.SwitchTo().Window(tab);
                }
            }
        }

        public static void SelectByText(By element, string dropdownText)
        {
            var dropDownList = driver.FindElement(element);
            var select = new SelectElement(dropDownList);
            select.SelectByText(dropdownText);
        }

        public static void SelectByIndex(By element, int index)
        {
            var dropDownList = driver.FindElement(element);
            var select = new SelectElement(dropDownList);
            select.SelectByIndex(index);
        }
        public static void SelectByValue(By element, string value)
        {
            var dropDownList = driver.FindElement(element);
            var select = new SelectElement(dropDownList);
            select.SelectByValue(value);
        }

        public static IList<IWebElement> GetAllOptions(By element)
        {
            var dropDownList = driver.FindElement(element);
            var select = new SelectElement(dropDownList);
            return select.Options;
        }

        public static void AcceptAlert()
        {
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
        public static void DismissAlert(IWebDriver driver)
        {
            var alert = driver.SwitchTo().Alert();
            alert.Dismiss();
        }
        public static string GetAlertText()
        {
            var alert = driver.SwitchTo().Alert();
            return alert.Text;
        }

        public static void SendTextToAlert(string text)
        {
            var alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
        }

        public static void SwitchToFrame(By frame)
        {
            var targetFrame = driver.FindElement(frame);
            driver.SwitchTo().Frame(targetFrame);
        }
        public void ScrollToElement(IWebDriver driver, By element)
        {
            var targetElement = driver.FindElement(element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public static void VerifyElementDisplayed(By element)
        {
            var targetElement = driver.FindElement(element);
            try
            {
               // Assert.Istrue(targetElement.Displayed, $"Element not visible: {targetElement} ");
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail("Element not found: " + targetElement);
            }
        }

        public static IWebElement WaitUntilElementExists(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static IWebElement WaitUntilElementVisible(By elementLocator, int timeout = 10)
        {

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }

        public static IWebElement WaitUntilElementClickable(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
        public static void ClickAndWaitForPageToLoad(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = driver.FindElement(elementLocator);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static List<String> GetTextofElements(By element)
        {
            var list = new List<string>();
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(element);
            foreach (IWebElement eachElement in elements)
            {
                list.Add(eachElement.Text);
                //Console.WriteLine(eachElement.Text);
            }
            return list;
        }
    }
}
