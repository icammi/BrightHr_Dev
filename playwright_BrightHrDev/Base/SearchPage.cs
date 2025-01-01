namespace playwright_newintegrationtests.Base
{
    public class SearchPage : BasePage
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly WebDriverFactory _driver;

        public SearchPage(IConfigurationRoot configurationRoot, WebDriverFactory driver) : base(driver)
        {
            this._configurationRoot = configurationRoot;
            this._driver = driver;
        }
        public IWebElement DetailSearch => _driver.Browser.FindElement(By.XPath("//div/button[@class='ant-btn ant-btn-primary ant-btn-circle ng-star-inserted']"));
        public IWebElement FixtureSerachTextBox => _driver.Browser.FindElement(By.XPath("//span[@class='ant-input-affix-wrapper ng-star-inserted']"));
        public IWebElement FixtureSerachButton => _driver.Browser.FindElement(By.XPath("//span[3]/button[@class='ant-btn ant-btn-primary ant-input-search-button ng-star-inserted']"));
        public IWebElement RadioButtonDates => _driver.Browser.FindElement(By.XPath("//span[1][@class='ant-radio ant-radio-checked']/input[@class='ant-radio-input']"));
        public IWebElement RadioButtonRelative => _driver.Browser.FindElement(By.XPath("//span[1][@class='ant-radio ant-radio-checked']/input[@class='ant-radio-input']"));
        public IWebElement FromDate => _driver.Browser.FindElement(By.XPath("//div[@class='ng-tns-c802749266-21 ant-picker-input ng-star-inserted']"));
        public IWebElement ToDate => _driver.Browser.FindElement(By.XPath("//div[@class='ng-tns-c802749266-23 ant-picker-input ng-star-inserted']"));
        public IWebElement Sport => _driver.Browser.FindElement(By.XPath("//div/div[@class='ant-form-item-control-input-content ng-tns-c630436078-40']"));
        public IWebElement Status => _driver.Browser.FindElement(By.XPath("//div/div[@class='ant-form-item-control-input-content ng-tns-c630436078-58']"));
        public IWebElement ResetClick => _driver.Browser.FindElement(By.XPath("//div[2]/div[1]/button[@class='ant-btn detail-search__reset_button ant-btn-round']"));
        public IWebElement SearchClick => _driver.Browser.FindElement(By.XPath("//div[2]/div[2]/button[@class='ant-btn detail-search__search_button ant-btn-primary']"));
        public IWebElement Virtuals => _driver.Browser.FindElement(By.XPath("//div[2][@class='ant-card-meta-detail ng-star-inserted']"));
        public IWebElement SearchFixture => _driver.Browser.FindElement(By.XPath("//div[@class='ant-tabs-tab-btn']"));
        public void SelectDetailSearch()
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            DetailSearch.Click();
        }
        public void validateVirtualsHome()
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            string PageHeader = "Search Fixtures";          
        }
    }
}
