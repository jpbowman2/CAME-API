using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

using CAME_API.Entities;

namespace CAME_API
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options) { }

        public DbSet<Work> tblMinistryWorks { get; set; }
    }
}

