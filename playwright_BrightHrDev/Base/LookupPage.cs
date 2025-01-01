namespace playwright_newintegrationtests.Base
{
    public class LookupPage : BasePage
    {
        private readonly WebDriverFactory _driver;

        public LookupPage(IConfigurationRoot configurationRoot, WebDriverFactory driver) : base(driver)
        {        
            this._driver = driver;
        }

        public IWebElement User => _driver.Browser.FindElement(By.XPath("//div[2][@class='ant-space-item']/span"));
        public IWebElement BentoMenu => _driver.Browser.FindElement(By.XPath("//div/nz-space/img"));
        public IWebElement AppHorseRacing => _driver.Browser.FindElement(By.XPath("//div/div[1]/nz-card/div/p"));
        public IWebElement AppVirtuals => _driver.Browser.FindElement(By.XPath("//div[2]/nz-card/div/p"));
        public IWebElement Homebtn => _driver.Browser.FindElement(By.XPath("//div[2]/ul/li/button"));

        //public IWebElement MenuDD => _driver.Browser.FindElement(By.ClassName("ant-menu-submenu-title"));
        //public IWebElement MenuDD => _driver.Browser.FindElement(By.XPath("//div[@class='ant-menu-submenu-title']"));

        public IWebElement MenuDD => _driver.Browser.FindElement(By.ClassName("ant-menu-submenu-title"));
        //public IWebElement MenuDD => _driver.Browser.FindElement(By.XPath("//div[@class='ant-menu-submenu-title']"));
        public IWebElement Signout => _driver.Browser.FindElement(By.XPath("//div/ul[@class='ng-star-inserted']/li"));
        public IWebElement SignoutYes => _driver.Browser.FindElement(By.XPath("/html/body/div/div/form/div/button"));
        public IWebElement Horseracing => _driver.Browser.FindElement(By.XPath("//div/nz-card-meta/div[2]/div[1][contains(text(),'Horse racing')]"));
        public IWebElement Virtuals => _driver.Browser.FindElement(By.XPath("//div/nz-card-meta[@nztitle='Virtuals']"));
        ///html/body/app-root/div/div/app-home/nz-layout/nz-content/div/div[2]/nz-card/div/nz-card-meta
        public IWebElement Signoutmsg => _driver.Browser.FindElement(By.XPath("/html/body/div/div/h1/small"));

        //public void selectSignout()
        //{
        //    WebDriverFactory.WaitDriverReady(_driver.Browser);
        //    MenuDD.Click();
        //    WebDriverFactory.WaitDriverReady(_driver.Browser);
        //    Signout.Click();
        //    WebDriverFactory.WaitDriverReady(_driver.Browser);
        //    SignoutYes.Click();
        //}

        public void selectSignout()
        {
            //   ChromeOptions options = new ChromeOptions();
            //   options.addArguments("no-sandbox");
            //   WebDriver driver = new ChromeDriver(options);
            //_driver.Browser..get("https://www.google.com/");

            WebDriverFactory.WaitDriverReady(_driver.Browser);
            //_driver.Browser.Close();
            //_driver.Browser.Quit();
            //    FindPageAttrtibutes("span", "class", "ant-menu-submenu-title").Click();
            //    FindPageAttrtibutes("span", "class", "ant-menu-title-content").Click();

            MenuDD.Click();
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            Signout.Click();
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            SignoutYes.Click();
        }

        public IWebElement FindPageAttrtibutes(string tagname, string tagattribute, string attributevalue)
        {
            if (_driver.Browser != null)
            {
                var byTagName = _driver.Browser.FindElements(By.TagName(tagname));
                foreach (IWebElement element in byTagName)
                {
                    var attrTag = element.GetAttribute(tagattribute);
                    if (attributevalue == element.GetAttribute(tagattribute))
                        //if (element.GetAttribute("className") == classname)
                    {
                        var attributeTagName = element.TagName;
                        var attributeTagValue = element.GetAttribute(tagattribute);
                        var attributeText = element.Text;
                        var attributeGetCssValue = element.GetCssValue;
                        var attributeGetType = element.GetType();
                        var attributeLocation = element.Location;

                        return element;
                        break;
                    }
                }
            }
            return null;
        }



        public void validateSignout()
        {
            string signoutText = "You are now logged out";
            ClassicAssert.IsTrue(Signoutmsg.Text.Equals(signoutText));
        }
        public void ValidateLookUpPage()
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            if (Virtuals.Displayed)
            { Console.WriteLine("virtuals"); }

        }
        public void ClickVirtuals()
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            Virtuals.Click();
        }
        public void CloseBrowser()  //igc
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            _driver.Browser.Close();
        }
        public void QuitBrowser()   //igc
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            _driver.Browser.Quit();
        }
    }
}
