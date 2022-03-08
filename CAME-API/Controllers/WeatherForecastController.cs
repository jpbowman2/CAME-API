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

        [HttpGet()]
        public ActionResult<List<ForecastSL>> GetAll()
        {

            List<Forecast> forecasts = /*await*/ repository.GetAll();
            var ForecastSLs = mapper.Map<List<ForecastSL>>(forecasts).ToList();
            return ForecastSLs;
        }

        [HttpGet("{id:int}", Name = "getNew")]
        public ActionResult<Forecast> GetOne(int Id)
        {
            Forecast f = /*await*/ repository.GetOne(Id);
            if (f==null) { 
                return NotFound(); 
            }
            return f;
        }

        [HttpPost]
        public ActionResult<Forecast> Post([FromBody] ForecastNew nf)
        {
            Forecast f = repository.Add(nf);
            return new CreatedAtRouteResult("getNew", new { id = f.Id }, f);
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, [FromBody] ForecastNew nf)
        {
            var b = repository.Update(id, nf);
            if (!b) { return NotFound(); }
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            var b = repository.Delete(id);
            if (!b) { return NotFound(); }
            return Ok();
        }

    }
}
