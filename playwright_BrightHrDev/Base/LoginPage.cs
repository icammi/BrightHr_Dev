namespace playwright_newintegrationtests.Base
{
    public class LoginPage : BasePage
    {
      
        private readonly SeleniumHelper _helper;
        private readonly WebDriverFactory _driver;

        public LoginPage(WebDriverFactory driver) : base(driver)
        {
            this._driver = driver;
        }
        public IWebElement UsernameTextbox => _driver.Browser.FindElement(By.XPath("//*[@id='Input_Username']"));
        public IWebElement Passwordtextbox => _driver.Browser.FindElement(By.XPath("//*[@id='Input_Password']"));
        public IWebElement LoginButton => _driver.Browser.FindElement(By.XPath("//button[text()='Login']"));

        public void Credentials(string username, string password)
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            UsernameTextbox.SendKeys(username);
            Passwordtextbox.SendKeys(password);
            LoginButton.Click();
        }
    }
}
