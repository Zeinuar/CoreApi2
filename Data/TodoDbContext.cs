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
            //for connection local db
            optionsBuilder.UseSqlServer(@"server=zein;database=DbTask;user id=sa;password=manuver;integrated security=true");
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
