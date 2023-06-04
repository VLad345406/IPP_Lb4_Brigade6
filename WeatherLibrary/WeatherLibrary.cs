using System.Net;
using System.IO;

namespace WeatherLibrary
{
    public class WeatherService
    {
        private const string apiKey = "b9b3388cad12afe98887c77776a0f6f7"; // Замените на ваш API-ключ OpenWeatherMap

        public static string GetTemperature(string city)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string jsonResponse = reader.ReadToEnd();

                    return jsonResponse;
                }
            }
            catch
            {
                return "Error!";
            }
        }
    }
}
