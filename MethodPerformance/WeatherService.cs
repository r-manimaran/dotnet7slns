using MethodTimer;
using Microsoft.AspNetCore.Mvc;

namespace MethodPerformance
{
    public class WeatherService

    {
        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //[Time("Getting Weather Report for {days} days")]
        [Time]
        public IEnumerable<WeatherForecast> GetWeatherForecast( int days = 5)
        {

            //     await Task.Delay(Random.Shared.Next(5, 25));
            Thread.Sleep(Random.Shared.Next(5, 20));
            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
