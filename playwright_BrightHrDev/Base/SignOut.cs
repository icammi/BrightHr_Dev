namespace playwright_newintegrationtests.Base
{
    public class SignOut : BasePage
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly WebDriverFactory _driver;

        public SignOut(IConfigurationRoot configurationRoot, WebDriverFactory driver) : base(driver)
        {
            _configurationRoot = configurationRoot;
            this._driver = driver;
        }

        public IWebElement UsernameTextbox => _driver.Browser.FindElement(By.Name("Input.Username"));
        public IWebElement Passwordtextbox => _driver.Browser.FindElement(By.Name("Input.Password"));
        public IWebElement LoginButton => _driver.Browser.FindElement(By.Name("/html/body/div[2]/div/div[2]/div/div/div[2]/form/button[1]"));
        public IWebElement ProfileIconButton => _driver.Browser.FindElement(By.XPath("/html/body/app-root/div/app-nav-menu/nz-header/div/div[2]/div/ul[2]/li/div/span[2]/nz-space/div[2]/span"));
        public IWebElement SignOutButton => _driver.Browser.FindElement(By.XPath("//*[@id=\"cdk-overlay-2\"]/div/div/ul/li"));
        public IWebElement LoggedOut => _driver.Browser.FindElement(By.XPath("/html/body/div[2]/div/h1/small"));


        public void Credentials(string username, string password)
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            UsernameTextbox.SendKeys("");
            Passwordtextbox.SendKeys("");
            LoginButton.Click();
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            ProfileIconButton.Click();
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            SignOutButton.Click();
        }

    }

}

    

