using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;

using CAME_API.Services;
using CAME_API.Entities;

namespace CAME_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastsRepository repository;
        private readonly IMapper mapper;

        public WeatherForecastController(
            //ILogger<WeatherForecastController> logger,
            IForecastsRepository repository,
            IMapper mapper
            )
        {
            //_logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("SL")]
        public ActionResult<IEnumerable<ForecastSL>> GetSL()
        {

            List<Forecast> f = /*await*/ repository.GetAll();
            var ForecastSLs = mapper.Map<List<ForecastSL>>(f);
            return ForecastSLs;
        }

        [HttpGet("Items")] 
        public ActionResult<IEnumerable<ForecastItem>> GetItems()
        {
            List<Forecast> f = /*await*/ repository.GetAll();
            var ForecastItems = mapper.Map<List<ForecastItem>>(f);
            return ForecastItems;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Forecast> GetOne(int Id)
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
