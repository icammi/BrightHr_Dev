using playwright_newintegrationtests.InterfacePoints.DbInterface;

namespace playwright_newintegrationtests.Support
{
    public static class Dependencies
    {
        private static readonly IWebDriver _driver;

        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();
            var config = RegisterConfig();
            var driver = new WebDriverFactory(config);

            builder.RegisterInstance(config).SingleInstance();
            builder.RegisterInstance(driver).SingleInstance();

           // builder.RegisterInstance(new LoginPage(driver)).SingleInstance();
            builder.RegisterInstance(new VirtualsPage(config, driver)).SingleInstance();
            //builder.RegisterInstance(new WebDriverFactory(config));
            //builder.RegisterInstance(new WebTCSearchStepDefinition(config,));
            builder.RegisterInstance(new LookupPage(config, driver)).SingleInstance();
           // builder.RegisterInstance(new LoginPage(config, WebDriverFactory.Browser));
            builder.RegisterInstance(new SearchPage(config, driver)).SingleInstance();
         
            builder.RegisterType<KafkaReader>().As<IKafkaReader>().SingleInstance();
            builder.RegisterType<DataUtility>().As<IDataUtility>().SingleInstance();
            builder.RegisterType<MsSqlController>().As<ISqlController>().SingleInstance();
            return builder;
        }
        private static IConfigurationRoot RegisterConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.env.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
