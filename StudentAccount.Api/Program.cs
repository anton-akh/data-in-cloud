using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentAccount.Dal;
using System;
using StudentAccount.Dal.Student;
using StudentAccount.Model.Student;
using StudentAccount.Orchestrators.Student;
using Microsoft.AspNetCore.Hosting;

namespace StudentAccount.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //public static void Main(string[] args)
        //{
        //    var builder = WebApplication.CreateBuilder(args);
        //    builder.Configuration.AddJsonFile("appsettings.json", false, true);

        //    // Add services to the container.

        //    builder.Services.AddControllers();
        //    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //    builder.Services.AddEndpointsApiExplorer();
        //    builder.Services.AddSwaggerGen();
            
        //    // Orchestrators
        //    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //    builder.Services.AddScoped<IStudentOrchestrator, StudentOrchestrator>();

        //    // Database
        //    builder.Services.AddScoped<IStudentRepository, StudentRepository>();


        //    builder.Services.AddSqlServer<Dal.AppDbContext>(builder.Configuration.GetConnectionString("DatabaseConnectionString"));

        //    var app = builder.Build();

        //    // Configure the HTTP request pipeline.
        //    if (app.Environment.IsDevelopment())
        //    {
        //        app.UseSwagger();
        //        app.UseSwaggerUI();
        //    }

        //    app.UseAuthorization();

        //    app.MapControllers();

        //    app.Run();
        //}
    }
}