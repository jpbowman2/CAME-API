﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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
        private readonly IMapper mapper;

        public WorksController(
            /*IWorksRepository repository,*/ 
            ApplicationDbContext context,
            IMapper mapper
            )
        {
            //this.repository = repository;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("Ministry/{MinistryID:int}")]
        public async Task<ActionResult<List<Work>>> GetAll(int MinistryID)
        {
            List<Work> works = await context.tblMinistryWorks.Where(x => x.MinistryID == MinistryID).AsNoTracking().ToListAsync();
            //var workDTOs = mapper.Map<List<ForecastItem>>(works);
            return works; // workDTOs;
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
        public async Task<ActionResult> Post([FromBody] NewWork nw) {
            Work w = mapper.Map<Work>(nw);
            context.Add(w);
            await context.SaveChangesAsync();
            return Ok(); // new CreatedAtRouteResult("getWork", new { Id = w.MinistryWorksID }, w);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] NewWork nw ) {
            var w = mapper.Map<Work>(nw);
            w.MinistryWorksID = id;
            context.Entry(w).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public void Delete() { }

    }
}
