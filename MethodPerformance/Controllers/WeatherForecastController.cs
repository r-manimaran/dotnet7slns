using MethodTimer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MethodPerformance.Controllers
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
        private readonly WeatherService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,WeatherService service)
        {
            _logger = logger;
            _service = service;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public async Task<IEnumerable<WeatherForecast>> Get()
        //{
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    try
        //    {
        //        await Task.Delay(Random.Shared.Next(5, 25));
        //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //            TemperatureC = Random.Shared.Next(-20, 55),
        //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //    }
        //    finally
        //    {
        //        watch.Stop();
        //        Console.WriteLine($"total time:{watch.ElapsedMilliseconds}ms");
        //    }
        //}

       
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get([FromQuery] int days)
        {
           
            //await Task.Delay(Random.Shared.Next(5, 25));

            //return Enumerable.Range(1, days).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
            return _service.GetWeatherForecast(days);
            
        }
    }
}