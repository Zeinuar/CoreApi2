using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo0912.Models;

namespace Todo0912.Data
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<TodoDbContext>());
            }
        }

        public static void SeedData(TodoDbContext context)
        {
            System.Console.WriteLine("Appling migrations..");
            context.Database.Migrate();
            if (!context.Todos.Any())
            {
                System.Console.WriteLine("Adding data..");
                context.Todos.AddRange(
                    new Todo() { Title = "Title A", Description = "Description A", Complete = 10, CreatedOn = DateTime.Now, ExpiredDate = DateTime.Now.AddDays(12) }
                    , new Todo() { Title = "Title B", Description = "Description B", Complete = 30, CreatedOn = DateTime.Now, ExpiredDate = DateTime.Now.AddDays(10) }
                    , new Todo() { Title = "Title C", Description = "Description C", Complete = 70, CreatedOn = DateTime.Now, ExpiredDate = DateTime.Now.AddDays(15) }
                    , new Todo() { Title = "Title D", Description = "Description E", Complete = 50, CreatedOn = DateTime.Now, ExpiredDate = DateTime.Now.AddDays(18) }
                    , new Todo() { Title = "Title E", Description = "Description F", Complete = 60, CreatedOn = DateTime.Now, ExpiredDate = DateTime.Now.AddDays(22) }

                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding..");
            }
        }

    }
}
