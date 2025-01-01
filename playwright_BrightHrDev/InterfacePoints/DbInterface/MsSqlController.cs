namespace playwright_newintegrationtests.InterfacePoints.DbInterface
{
    public class MsSqlController : ISqlController
    {
        private readonly IConfigurationRoot _configurationRoot;

        public MsSqlController(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public bool CanConnect(string connectionName)
        {
            try
            {
                var connectionString = _configurationRoot.GetConnectionString(connectionName);
                using var connection = new SqlConnection(connectionString);

                connection.Open();
                connection.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T>? RunCommand<T>(string connectionName, string queryText, IEnumerable<DbParameter>? parameters = null)
            where T : class, new()
        {
            var connectionString = _configurationRoot.GetConnectionString(connectionName);
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            using var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = queryText;

            ApplyParameters(parameters, sqlCommand);

            using var dataReader = sqlCommand.ExecuteReader();

            return GetResults<T>(dataReader);
        }

        private static void ApplyParameters(IEnumerable<DbParameter>? parameters, SqlCommand sqlCommand)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    sqlCommand.Parameters.Add(parameter);
                }
            }
        }

        private static IEnumerable<T> GetResults<T>(SqlDataReader dataReader) where T : class, new()
        {
            var results = new List<T>();
            while (dataReader.Read())
            {
                results.Add(dataReader.Deserialize<T>());
            }
            return results;
        }
    }
}

