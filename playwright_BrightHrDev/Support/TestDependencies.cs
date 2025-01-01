namespace playwright_newintegrationtests.Support
{
    [Binding]
    public sealed class TestDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = Dependencies.CreateContainerBuilder();

            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();

            return builder;
        }
    }
}