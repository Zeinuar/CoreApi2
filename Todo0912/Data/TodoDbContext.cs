using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo0912.Models;

namespace Todo0912.Data
{
    public class TodoDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"server=.;database=DbTask;integrated security=true");
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
