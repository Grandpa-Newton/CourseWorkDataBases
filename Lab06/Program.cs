
using Lab06;
using Lab06.Models;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lab06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Testing System",
                    Description = "Система для тестирования"
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "TestingSystemAPI.xml");
                options.IncludeXmlComments(xmlPath);
            });

            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            /*   services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(connection));*/

            builder.Services.AddDbContext<TestingSystemDbContext>(options => options.UseSqlServer(connection));

            builder.Services.AddMvc();
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseDefaultFiles();

            app.UseStaticFiles();


            app.MapControllers();

            app.Run();
        }
    }
}