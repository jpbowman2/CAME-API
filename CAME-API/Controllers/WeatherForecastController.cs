using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CAME_API.Services;
using CAME_API.Entities;

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
        private readonly IForecastsRepository repository;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecastsRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet("SL")]
        public async Task<ActionResult<IEnumerable<Forecast>>> GetSL()
        {

            List<Forecast> f = /*await*/ repository.GetAll();
            return f;
        }

        [HttpGet("Items")] 
        public async Task<ActionResult<IEnumerable<Forecast>>> GetItems()
        {
            List<Forecast> f = /*await*/ repository.GetAll();
            return f;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Forecast>> GetOne(int Id)
        {
            Forecast f = /*await*/ repository.GetOne(Id);
            if (f==null) { 
                return NotFound(); 
            }
            return f;
        }

        [HttpPost]
        public void Post() { }

        [HttpPut]
        public void Put() { }

        [HttpDelete]
        public void Delete() { }

    }
}
