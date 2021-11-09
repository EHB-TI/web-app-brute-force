﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHikeB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EHikeB.Data
{
    public class EHikeBContext : IdentityDbContext<Customer>
    {
        public EHikeBContext(DbContextOptions<EHikeBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}