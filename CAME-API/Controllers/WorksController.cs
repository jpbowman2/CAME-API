using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CAME_API.Services;
using CAME_API.Entities;

namespace CAME_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorksController: ControllerBase
    { 
        //private readonly IWorksRepository repository;
        private readonly ApplicationDbContext context;
        public WorksController(/*IWorksRepository repository,*/ ApplicationDbContext context)
        {
            //this.repository = repository;
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Work>>> GetAll()
        {
            //return /*await*/ repository.GetAll();
            return await context.tblMinistryWorks.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Work>> GetOne(int Id)
        {
            var w = await context.tblMinistryWorks.FirstOrDefaultAsync(x => x.MinistryWorksID == Id);
            if (w == null) {
                return NotFound();
            };
            return w;
        }

        [HttpPost]
        public void Post() { }

        [HttpPut]
        public void Put() { }

        [HttpDelete]
        public void Delete() { }

    }
}
