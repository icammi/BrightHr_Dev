namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base
{
    public class ApiConnection
    {
        public static string[] GetApuUrl(string sport)
        {
            string apiUrl = "";

            StreamReader reader = File.OpenText("Add file path");
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                Debug.Assert(line != null, nameof(line) + " != null");
                if (line.Contains(sport))
                {
                    Console.WriteLine(line);
                }
            }
            return new string[] { apiUrl };
        }

        public static string[] GetJson(string sport, string apiAction, string eventName)
        {
            string json = "";

            StreamReader reader = File.OpenText("C:local\\Test Interfaces points\\API Interface\\Json Files\\" + sport + "_" + apiAction + "_" + eventName + "_jSon.csv");
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                /*Debug.Assert(line != null, nameof(line) + " != null");
                if (line.Contains(urlEndpointName))
                {
                    Console.WriteLine(line);
                }*/
            }
            return new string[] { json };
        }


        public static async void InteractWithApi(string apiAction, string apiName)
        {

            if (apiAction == "post")
            {
                // var responseString = await apiUrl + "POST".PostUrlEncodedAsync(new { jSonToBeSent }).ReceiveString();
            }

            if (apiAction == "get")
            {
                // var responseString = await apiUrl + "GET".GetStringAsync();
            }
        }
    }
}