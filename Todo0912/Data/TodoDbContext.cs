﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo0912.Models;

namespace Todo0912.Data
{
    public class TodoDbContext:DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options):base(options){
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
