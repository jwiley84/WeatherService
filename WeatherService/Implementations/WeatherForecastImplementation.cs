using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherService.Implementations
{
    public class WeatherForecastImplementation
    {
        internal static WeatherForecast GetWeatherForecast()
        {
            //todo: retreive current temperature from:
            //https://www.weatherbit.io/api/swaggerui/weather-api-v2#!/Current32Weather32Data/get_current_postal_code_postal_code
            //using API Key: 1824631bbfa74729aac7d2d2f1dfdd76
            
            string key = "1824631bbfa74729aac7d2d2f1dfdd76";

            string postal_code = "98405";
            string url = string.Format("https://api.weatherbit.io/v2.0/current?postal_code={0}&key={1}", postal_code, key);
            

            HttpClient client = new HttpClient();
            HttpResponseMessage res = client.GetAsync(url).GetAwaiter().GetResult();
            
            var forecast = new WeatherForecast();


            if (res.IsSuccessStatusCode) {
               var response = res.Content.ReadAsStringAsync().Result;

                JObject result = JsonConvert.DeserializeObject<JObject>(response);
                dynamic reslt = result["data"].First();

                forecast.temp_C = reslt["temp"];
                forecast.temp_F = (reslt["temp"] * (9 / 5)) + 32;
                forecast.date = DateTime.Now;
            
            } 



            return forecast;
        }
    }
}
