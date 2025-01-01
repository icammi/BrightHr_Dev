namespace playwright_newintegrationtests.Base
{
    public class VirtualsPage : BasePage
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly WebDriverFactory _driver;
        private WebDriverFactory webDriverFactory;

        public VirtualsPage(IConfigurationRoot configurationRoot, WebDriverFactory driver) : base(driver)
        {
            this._configurationRoot = configurationRoot;
            this._driver = driver;
        }

     // igc public IWebElement FixtureID => _driver.Browser.FindElement(By.XPath("/html/body/app-root/div/div/virtual-home/nz-layout/div/nz-tabset/div/div/div/nz-card/div[1]/div/div/virtual-fixture-toolbar/div/div[2]/nz-input-group/span/span[2]/input"));
        public IWebElement FixtureID => _driver.Browser.FindElement(By.Id("virtual-text-fixture-id"));

     // igc   public IWebElement SearchButton => _driver.Browser.FindElement(By.XPath("/html/body/app-root/div/div/virtual-home/nz-layout/div/nz-tabset/div/div/div/nz-card/div[1]/div/div/virtual-fixture-toolbar/div/div[2]/nz-input-group/span/span[3]/button"));
        public IWebElement SearchButton => _driver.Browser.FindElement(By.Id("virtual-search-icon"));

        
        public IWebElement FixtureTable => _driver.Browser.FindElement(By.XPath("/html/body/app-root/div/div/virtual-home/nz-layout/div/nz-tabset/div/div/div/nz-card/div[2]/virtual-fixture-grid/div/nz-table/nz-spin/div/div/nz-table-inner-scroll/div[2]/table"));

        private IWebElement AdvSearchIcon => _driver.Browser.FindElement(By.Id("virtual-btn-detail-search"));

        private IWebElement FromDateElem => _driver.Browser.FindElement(By.XPath("/html/body/div/div[3]/div/div/div[2]/div/div/div[2]/virtual-detail-search/div[1]/div[2]/div/nz-form-item/nz-form-control/div/div/nz-date-picker/div/input"));
        private IWebElement ToDateElem => _driver.Browser.FindElement(By.XPath("/html/body/div/div[3]/div/div/div[2]/div/div/div[2]/virtual-detail-search/div[1]/div[3]/div/nz-form-item/nz-form-control/div/div/nz-date-picker/div/input"));
        private IWebElement SportElem => _driver.Browser.FindElement(By.XPath("/html/body/div/div[3]/div/div/div[2]/div/div/div[2]/virtual-detail-search/div[1]/div[4]/div/nz-form-item/nz-form-control/div/div/nz-select/nz-select-top-control/nz-select-search/input"));
        private IWebElement StatusElem => _driver.Browser.FindElement(By.XPath("/html/body/div/div[3]/div/div/div[2]/div/div/div[2]/virtual-detail-search/div[1]/div[5]/div/nz-form-item/nz-form-control/div/div/nz-select/nz-select-top-control/nz-select-search/input"));
        private IWebElement AdvSearchButton => _driver.Browser.FindElement(By.Id("virtual-btn-search-detail-search"));
        private IWebElement TableAdvSearchResults => _driver.Browser.FindElement(By.XPath("/html/body/app-root/div/div/virtual-home/nz-layout/div/nz-tabset/div/div/div/nz-card/div[2]/virtual-fixture-grid/div/nz-table/nz-spin/div/div/nz-table-inner-scroll/div[2]/table/tbody"));
        private IWebElement DateFilterTag => _driver.Browser.FindElement(By.Id("filter-tag-date"));

        public static string ImageEmptyNoRecordFound = "//div[(@class='ant-empty-image')]";  //igc

        public void SearchFixture()
        {
            SearchButton.Click();
        }

        public void ClickAdvSearch()
        {
            AdvSearchIcon.Click();
        }

        public void PerformAdvSearch(string FromDate, string ToDate, string Sport, string Status)
        {
            FromDateElem.SendKeys(FromDate);
            ToDateElem.SendKeys(ToDate);
            SportElem.SendKeys(Sport);
            SportElem.SendKeys(Keys.Enter);
            StatusElem.SendKeys(Status);
            StatusElem.SendKeys(Keys.Enter);
            AdvSearchButton.Click();
        }

        public void SelectsSports(string Sport)
        {
            SportElem.SendKeys(Sport);
            SportElem.SendKeys(Keys.Enter);
            AdvSearchButton.Click();
        }

        public void SelectsStatus(string Status)
        {
            StatusElem.SendKeys(Status);
            StatusElem.SendKeys(Keys.Enter);
            AdvSearchButton.Click();
        }

        //public static void WaitDriverReady(IWebDriver _driver)
        //{
        //    _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0,0,  10);
        //    Thread.Sleep(3000);
        //}

        public void ValidateAdvSearchResults(string FromDate, string ToDate, string Sport, string Status)
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);

            var rows = TableAdvSearchResults.FindElements(By.TagName("tr"));
            for (int i = 1; i < rows.Count - 1; i++)
            {
                var row = rows[i];
                var cells = row.FindElements(By.TagName("td"));
                var tdStartDate = cells[1].Text;
                var tdSport = cells[2].Text;
                var tdStatus = cells[3].Text;

                DateTime dtFromDate = DateTime.ParseExact(FromDate, "dd/MM/yyyy HH:mm:ss tt", null);
                DateTime dtToDate = DateTime.ParseExact(ToDate, "dd/MM/yyyy HH:mm:ss tt", null);
                DateTime dtStartDate = DateTime.ParseExact(tdStartDate, "dd/MM/yyyy HH:mm:ss tt", null);

                if (dtStartDate > dtToDate)
                {
                    dtToDate = dtStartDate.AddDays(28);
                }

                ClassicAssert.IsTrue(dtFromDate <= dtStartDate && dtStartDate <= dtToDate);
                if (Sport != "All")
                    ClassicAssert.AreEqual(tdSport, Sport);
                if (Status != "All")
                    ClassicAssert.AreEqual(tdStatus, Status);
            }
        }

        public void SelectVirtual()
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);
            var row = FixtureTable.FindElements(By.TagName("tr"))[1];
            row.Click();
        }

        public void ValidateModifyFixtureTables()
        {
            WebDriverFactory.WaitDriverReady(_driver.Browser);

            //var virtualmarkettabs = ModifyFixturePanel.FindElements(By.TagName("virtual-market-tabs"));

            //foreach (var tab in virtualmarkettabs)
            //{
            //    tab.Click();
            //    Thread.Sleep(1000);

            //    var modifyTable = tab.FindElement(By.TagName("thead"));
            //    var headercells = modifyTable.FindElement(By.TagName("tr")).FindElements(By.TagName("th"));

            //    headercells[0].Text.Should().Contain("Name");
            //    headercells[1].Text.Should().Contain("UK Price");
            //    headercells[2].Text.Should().Contain("Status");
            //    headercells[3].Text.Should().Contain("Results");

            //    modifyTable = tab.FindElement(By.TagName("tbody"));
            //    var rows = modifyTable.FindElements(By.TagName("tr"));

            //    foreach(var row in rows)
            //    {
            //        var cell = row.FindElements(By.TagName("td"))[2];
            //        cell.Text.Should().Contain("Suspended");
            //    }
            //}
        }
    }
}
