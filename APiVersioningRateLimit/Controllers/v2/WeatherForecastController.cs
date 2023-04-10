using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace APiVersioningRateLimit.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiVersion("2.1")]
    [EnableRateLimiting("FixedWindowPolicy")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [MapToApiVersion("2.0")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Summary from Version2.0"
            })
            .ToArray();
        }

        [HttpGet(Name = "GetWeatherForecastv21")]
        [MapToApiVersion("2.1")]
        [EnableRateLimiting("FixedWindowPolicy")]
        public IEnumerable<WeatherForecast> GetV21()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Summary from Version2.1"
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetRandomNumber")]
        [MapToApiVersion("2.1")]
        [EnableRateLimiting("SlidingWindowPolicy")]
        public IActionResult GetRandomNumber()
        {
            return Ok(Random.Shared.Next());  
        }

        [HttpGet]
        [Route("GetGreetings")]
        [MapToApiVersion("2.1")]
        [EnableRateLimiting("ConcurrentRatePolicy")]
        public IActionResult GetGreeting()
        {
            return Ok("Hello! Have a nice day.");
        }

        [HttpGet]
        [Route("GetName")]
        [MapToApiVersion("2.1")]
        [EnableRateLimiting("TokenBucketPolicy")]
        public IActionResult GetName()
        {
            return Ok("TokenBucket Rate Limiting");
        }
    }
}