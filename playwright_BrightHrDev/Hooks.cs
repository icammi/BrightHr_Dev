
namespace playwright_newintegrationtests
{
    [Binding]
    public class Hooks
    {
        private IWebDriver driver;
        private readonly IObjectContainer container;
        private readonly ScenarioContext _scenarioContext;
        private readonly IConfigurationRoot _configurationRoot;
        private readonly WebDriverFactory _webDriverFactory;
        private static FeatureContext _featureContext;

        public Hooks(
            IObjectContainer container,
            ScenarioContext scenarioContext,
            IConfigurationRoot configurationRoot,
            WebDriverFactory webDriverFactory)
        {
            this.container = container;
            _scenarioContext = scenarioContext;
            _configurationRoot = configurationRoot;
            _webDriverFactory = webDriverFactory;
        }

        [BeforeScenario]
        public void BeforeFeature(ScenarioContext featureContext)
        {
            RunWebTC();
        }

        
        public void RunWebTC()
        {
            string[] tagsArray = _scenarioContext.ScenarioInfo.Tags;
            var isWebTC = tagsArray.Contains("WebTC");
            if (isWebTC)
            {
                _webDriverFactory.GetDriver();
                _webDriverFactory.GoToWebTc();
            }
            else
            {
                return;
            }
        }

        [AfterScenario]
        public void Cleanup()
        {
            if (driver != null)
            {
                driver = _webDriverFactory.Browser;
                //var driver = container.Resolve<IWebDriver>();
                driver.Quit();
            }
        }
    }

}
