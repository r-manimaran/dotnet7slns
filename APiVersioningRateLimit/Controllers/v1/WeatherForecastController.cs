using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace APiVersioningRateLimit.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0",Deprecated =true)]
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
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetRandomNumber")]
        [MapToApiVersion("1.0")]
        [EnableRateLimiting("SlidingWindowPolicy")]
        public IActionResult GetRandomNumber()
        {
            return Ok(Random.Shared.Next());
        }

        [HttpGet]
        [Route("GetGreetings")]
        [MapToApiVersion("1.0")]
        [EnableRateLimiting("ConcurrentRatePolicy")]
        public IActionResult GetGreeting()
        {
            return Ok("Hello! Have a nice day.");
        }

        [HttpGet]
        [Route("GetName")]
        [MapToApiVersion("1.0")]
        [EnableRateLimiting("TokenBucketPolicy")]
        public IActionResult GetName()
        {
            return Ok("TokenBucket Rate Limiting");
        }
    }
}