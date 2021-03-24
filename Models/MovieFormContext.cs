using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public class MovieFormContext: DbContext
    {
        public MovieFormContext (DbContextOptions<MovieFormContext> options) : base(options)
        {
        }
        public DbSet<MovieFormModel> Movies { get;set; }
    }
}
