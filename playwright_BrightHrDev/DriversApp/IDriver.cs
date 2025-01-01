namespace playwright_newintegrationtests.DriversApp
{
    public interface IDriver
    {
        IPage Page { get; }

        Task<IPage> InitializePlaywright();
    }
}