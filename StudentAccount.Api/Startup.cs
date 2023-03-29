using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentAccount.Dal.Student;
using StudentAccount.Model.Student;
using StudentAccount.Orchestrators.Student;
using StudentAccount.Platform.Exception;
using System;

namespace StudentAccount.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // Orchestrator
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IStudentOrchestrator, StudentOrchestrator>();

        // Dal
        services.AddScoped<IStudentRepository, StudentRepository>();
        ConfigureDb(services);
    }

    protected virtual void ConfigureDb(IServiceCollection services)
    {
        services.AddSqlServer<Dal.AppDbContext>(_configuration.GetConnectionString("DatabaseConnectionString"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<GlobalErrorHandlingMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        app.UseEndpoints(action => action.MapControllers());
    }
}