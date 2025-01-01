using ClassConfiguration;
using ClassCryption;

namespace playwright_newintegrationtests.PlaywrightCode
{
    public class RepeatableActions : PageTest
    {
        public static async Task ActionDriver()
        {
            ConfigDateTime.mctime = DateTime.Now;
            ConfigDateTime.FormattedTime(ConfigDateTime.mctime);
            ConfigDateTime.mctime.ToString("yyyy-MM-dd");
            ConfigDateTime.mctime.AddYears(1).ToString("yyyy-MM-dd");

            ConfigDateTime.starttime = Convert.ToDateTime(ConfigDateTime.mctime);

            DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            _ = "fileName_" + DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss.fff") + ".pdf";

            Config.EnvironmentVARIABLE._PRIMEKEY = Environment.GetEnvironmentVariable("AESOPERATION_PRIMEKEY");

            AESOperation.PRIMEKEY = Environment.GetEnvironmentVariable("AESOPERATION_PRIMEKEY");     // "b14ca5898a4e4133bbce2ea2315a1916";
            AESOperation.KEYTEXT = Environment.GetEnvironmentVariable("AESOPERATION_KEYTEXT");      // Example "Hello, Baha'is of the World!";

            AESOperation.PLAINTEXT = Environment.GetEnvironmentVariable("AESOPERATION_DEFAULTTEXT"); // "Hello, Baha'is of the World!";

            //   CryptionEngine._testsecuritykey = Environment.GetEnvironmentVariable("_KEYWORD");
            //   var encryptionVariable          = CryptionEngine.Encrypt_Text(CryptionEngine._testsecuritykey);
            //   var decryptionVariable          = CryptionEngine.Decrypt_Text(encryptionVariable);

            // var strText = AESOperation.strText;
            // var keyText = AESOperation.keyText;
            AESOperation.ENVKEYTEXT = AESOperation.PRIMEKEY;

            var cryptionVariable = AESOperation.Encrypted("AESOPERATION_TESTPASSWORD");

            var decryptionVariable = AESOperation.Decrypted(Environment.GetEnvironmentVariable("AESOPERATION_TESTUSERID_ENCRYPTED"));
            var encryptionVariable = AESOperation.Encrypted(Environment.GetEnvironmentVariable("AESOPERATION_TESTUSERID_DECRYPTED"));

            decryptionVariable = AESOperation.Decrypted(Environment.GetEnvironmentVariable("AESOPERATION_TESTPASSWORD_ENCRYPTED"));
            encryptionVariable = AESOperation.Encrypted(Environment.GetEnvironmentVariable("AESOPERATION_TESTPASSWORD_DECRYPTED"));
        }

        public static async Task WaitForElement(IWebDriver _driver, IWebElement element)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(25));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static async Task DoubleClickElement(IWebDriver _driver, IWebElement element)
        {
            //   var actions = new Actions(_driver);
            //   WaitForElement(_driver, element);
            //   actions.MoveToElement(element).DoubleClick().Build().Perform();
        }

        public static async Task FluentWait(IWebDriver _driver, IWebElement element)
        {
            var fluentWait = new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            fluentWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            fluentWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public static async Task<string> EnvironmentVariableSET(string PrimeKEY, string Environment_Key, string Environment_Value)
        {
            var setKey = PrimeKEY + Environment_Key;

            Environment.SetEnvironmentVariable(setKey, Environment_Value);

            if (Environment.GetEnvironmentVariable(setKey) != null)
            {
                TestContext.Progress.WriteLine("Using Environment variable provided | " + setKey + ": {0}", Environment.GetEnvironmentVariable(setKey));
                return ""; // EnvironmentVariableGET(Environment_Key);
            }

            return string.Empty;
        }

        public static async Task<string> EnvironmentVariableGET(string Environment_Key)
        {
            return "";
            //*//return Environment.GetEnvironmentVariable(Config.EnvironmentVARIABLE._PRIMEKEY + Environment_Key);
        }

        public static async Task<string> EnvironmentVariableVALIDATE(string Prime, string Environment_Key, string Environment_Value)
        {
            if (!String.IsNullOrEmpty(Environment_Key))
            {
                //*//var setKey = Config.EnvironmentVARIABLE._PRIMEKEY + Environment_Key;

                EnvironmentVariableSET(Prime, Environment_Key, Environment_Value);

                return Environment_Value;
            }

            return string.Empty;
        }

        public static async Task ActionCypher()
        {
            // public static string exstrText = "Hello, Baha'is of the World!";
            // public static string exkeyText = "b14ca5898a4e4133bbce2ea2315a1916";

            //AESOperation.plainText  = "Hello, Baha'is of the World!";
            //AESOperation.keyText    = "b14ca5898a4e4133bbce2ea2315a1916";
            //AESOperation.cypherText = AESOperation.primecypher;
            //AESOperation.primeText  = AESOperation.Decrypted();
            //AESOperation.envKeyText = AESOperation.Decrypted();

            //// operation 1
            //AESOperation.cypherText = AESOperation.Encrypted();
            //AESOperation.objectdecrypted = AESOperation.Decrypted();

            //// operation 2
            //AESOperation.cypherText = AESOperation.Encrypted(AESOperation.plainText);
            //AESOperation.objectdecrypted = AESOperation.Decrypted(AESOperation.cypherText);

            //// operation 3
            //AESOperation.cypherText = AESOperation.Encrypted(AESOperation.keyText, AESOperation.plainText);
            //AESOperation.objectdecrypted = AESOperation.Decrypted(AESOperation.keyText, AESOperation.cypherText);
        }

    }
}

