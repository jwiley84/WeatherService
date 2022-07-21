using Microsoft.AspNetCore.Mvc;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly Dictionary<int, string> Summaries = new Dictionary<int, string>(){{0,
            "Freezing" }, {4,"Bracing" }, {10,"Chilly" } , {16,"Cool" }, {21,"Mild" }, {27,"Warm" }, {32,"Hot" }, {38,"Sweltering" }, {43,"Scorching" }
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetForecast")]
        public WeatherForecast Get()
        {
            WeatherForecast forecast = WeatherService.Implementations.WeatherForecastImplementation.GetWeatherForecast();

            int temp = forecast.temp_C;
            if (temp >= 43)
            {
                forecast.summary = Summaries[43];
            }
            else if (temp >= 38)
            {
                forecast.summary = Summaries[38];
            }
            else if (temp >= 32)
            {
                forecast.summary = Summaries[32];
            }
            else if (temp >=27)
            {
                forecast.summary = Summaries[27];
            }
            else if (temp >= 21)
            {
                forecast.summary = Summaries[21];
            } 
            else if (temp >= 10)
            {
                forecast.summary = Summaries[10];
            } 
            else if (temp >= 4)
            {
                forecast.summary = Summaries[4];
            }
            else
            {
                forecast.summary = Summaries[0];
            }
            return forecast;
        }
    }
}