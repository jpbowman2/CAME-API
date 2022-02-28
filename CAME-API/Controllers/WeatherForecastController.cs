using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAME_API.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("SL")]
        public IEnumerable<WeatherForecastSL> GetSL()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastSL
            {
                Pk = index,
                Extra = false,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
            })
            .ToArray();
        }

        [HttpGet("Items")] //[HttpGet("{WeatherID:int}")]
        public IEnumerable<WeatherForecastItems> GetItems()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastItems
            {
                Pk = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

    }
}
