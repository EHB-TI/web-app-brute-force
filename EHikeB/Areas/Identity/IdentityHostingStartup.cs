using System;
using EHikeB.Data;
using EHikeB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EHikeB.Areas.Identity.IdentityHostingStartup))]
namespace EHikeB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EHikeBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EHikeBContextConnection")));

                services.AddDefaultIdentity<Customer>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<EHikeBContext>();
            });
        }
    }
}