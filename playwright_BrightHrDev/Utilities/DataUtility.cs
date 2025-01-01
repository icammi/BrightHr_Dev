namespace playwright_newintegrationtests.Utilities
{
    public class DataUtility : IDataUtility
    {
        private string _frameworkLocation = string.Empty;
        private readonly IConfigurationRoot _configurationRoot;

        public DataUtility(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string FrameworkLocation
        {
            get
            {
                if (_frameworkLocation == string.Empty)
                {
                    _frameworkLocation = GetFrameworkLocation();
                }
                return _frameworkLocation;
            }
        }

        /// <summary>
        /// Takes any specflow table and transforms it to a datatable where all columns are type string
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(Table t)
        {
            var dT = new DataTable();
            foreach (var h in t.Header)
            {
                dT.Columns.Add(h, typeof(string));
            }
            // iterating rows
            foreach (var row in t.Rows)
            {
                var n = dT.NewRow();
                foreach (var h in t.Header)
                {
                    n.SetField(h, row[h]);
                }
                dT.Rows.Add(n);
            }
            return dT;
        }

        public static Dictionary<string, string> GetDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public string GetJsonFileData(string fileName)
        {
            var testFilePath = Path.Join(
                FrameworkLocation,
                _configurationRoot.GetSection("Shared:JsonTestFiles").Value
                    .Replace("/", Path.DirectorySeparatorChar.ToString()),
                fileName
            );

            return File.ReadAllText(testFilePath, Encoding.UTF8) ?? string.Empty;
        }

        private static string GetFrameworkLocation()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var frameworkLocation = assembly.Location;
            frameworkLocation = frameworkLocation.Replace($"{Assembly.GetExecutingAssembly().GetName().Name}.dll", "");
            return frameworkLocation;
        }
    }
}
