using Lab05New.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Lab05New.Middleware;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Http.Features;

namespace Lab05New
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string? connection = Configuration.GetConnectionString("DefaultConnection");
         /*   services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));*/

            services.AddDbContext<TestingSystemDbContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TestingSystemDbContext>()
                .AddDefaultTokenProviders();

            // services.AddControllers();
            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("Caching",
                    new CacheProfile()
                    {
                        Duration = 256
                    });
            });

            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });

            services.AddSession();

            services.AddMemoryCache();
           // services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


         //   app.UseAuthentication();

            app.UseStaticFiles();

            app.UseSession();

            app.UseDbInitializer();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
