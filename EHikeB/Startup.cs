using EHikeB.Data;
using EHikeB.Models;
using Matrixsoft.PwnedPasswords;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<Customer>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<PwnedPasswordsClient>();
            services.AddControllersWithViews();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddRazorPages();
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseCookiePolicy();
                app.UseXXssProtection(options => options.EnabledWithBlockMode());
                app.UseCsp(opts => opts
                    .BlockAllMixedContent()
                    .DefaultSources(s => s.Self())
                    .DefaultSources(s => s.CustomSources("https://images.unsplash.com/","data:", "https:"))
                    .ScriptSources(s => s.Self())
                    .ScriptSources(s => s.UnsafeInline())
                    .ScriptSources(s => s.UnsafeEval())
                    .ScriptSources(s => s.CustomSources("https://ajax.aspnetcdn.com", "https://cdn.jsdelivr.net"))
                    .StyleSources(s => s.Self())
                    .StyleSources(s => s.UnsafeInline())
                    .StyleSources(s => s.CustomSources("https://cdn.jsdelivr.net"))
                    .FontSources(s => s.Self())
                    .FontSources(s => s.CustomSources("https://fonts.gstatic.com", "https://cdn.jsdelivr.net"))

                ) ;
                app.UseXfo(options => options.Deny());
                app.UseXContentTypeOptions();
                app.UseReferrerPolicy(options => options.NoReferrer());
                app.Use(async (context, next) =>
                {
                    context.Response.Headers.Remove("Server");
                    context.Response.Headers.Remove("X-Powered-By");
                    context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");
                    await next();
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
