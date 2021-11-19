using EHikeB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Data
{
    public static class SeedDb
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Locations.Any())
            {
                string text = System.IO.File.ReadAllText(@"wwwroot/zip.json");
                var list = JsonConvert.DeserializeObject<List<Location>>(text);
                context.AddRange(list);
            }
            else
            {
                return;
            }

            //if (context.Customers.Any())
            //{
            //    return;
            //}

            ////Customers
            //var customer1 = new Customer() { };

            //context.Customers.AddRange(new Customer[] { customer1 });


            ////Cars
            //var car1 = new Car() { };

            //context.Cars.AddRange(new Car[] { car1 });


            ////Sessions
            //var session1 = new Session() { };

            //context.Sessions.AddRange(new Session[] { session1 });



            context.SaveChanges();

        }
    }
}