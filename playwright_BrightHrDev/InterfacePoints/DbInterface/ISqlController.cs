namespace playwright_newintegrationtests.InterfacePoints.DbInterface
{
    public interface ISqlController
    {
        IEnumerable<T>? RunCommand<T>(string connectionName, string queryText, IEnumerable<DbParameter>? parameters = null) where T : class, new();
        bool CanConnect(string connectionName);
    };
}

