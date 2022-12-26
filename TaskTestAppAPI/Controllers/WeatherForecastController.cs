using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
namespace TaskTestAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private IWebHostEnvironment _hostingEnv;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _hostingEnv = env;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            string FilePath = Path.Combine(_hostingEnv.WebRootPath);


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}