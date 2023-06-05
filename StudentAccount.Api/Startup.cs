using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentAccount.Dal.Student;
using StudentAccount.Model.Student;
using StudentAccount.Orchestrators.Student;
using StudentAccount.Platform.Exception;
using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StudentAccount.Dal.Class;
using StudentAccount.Model.Class;
using StudentAccount.Model.CourseStudent;
using StudentAccount.Orchestrators.Class;
using StudentAccount.Orchestrators.CourseStudent;
using StudentAccount.Platform.BlobStorage;
using Azure.Messaging.ServiceBus;
using StudentAccount.Model.ClassStats;
using StudentAccount.Orchestrators.ClassStatsOrchestrator;
using StudentAccount.Platform.ServiceBus;

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
        services.AddScoped<IClassOrchestrator, ClassOrchestrator>();
        services.AddScoped<IClassStatsOrchestrator, ClassStatsOrchestrator>();
        services.AddScoped<ICourseStudentOrchestrator, CourseStudentOrchestrator>();
        services.AddScoped<StatsContainer, StatsContainer>();

        // Dal
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        ConfigureDb(services);

        var config = new BlobConfiguration();
        _configuration.Bind("AzureBlobConnectionString", config);

        services.AddSingleton(config);

        // misc
        services.AddScoped<IBlobStorage, BlobStorage>();

        ConfigureEdgeService(services);
    }

    protected virtual void ConfigureEdgeService(IServiceCollection services)
    {
        services.AddTransient(typeof(ServiceBusClient),
            builder => new ServiceBusClient(_configuration.GetConnectionString("ServiceBusConnectionString")));

        services.AddScoped<IPublisher, ClassSatsPublisher>();

        var subscriber = new ClassStatsSubscriber((ServiceBusClient)services.BuildServiceProvider().GetService(typeof(ServiceBusClient)));
        subscriber.SubscribeAsync().GetAwaiter().GetResult();

        services.AddSingleton<ISubscriber>(subscriber);
    }

    protected virtual void ConfigureDb(IServiceCollection services)
    {
        services.AddSqlServer<Dal.AppDbContext>(_configuration.GetConnectionString("DatabaseConnectionString"));
        services.AddCosmos<Dal.CosmosDbContext>(_configuration.GetConnectionString("CosmosConnectionString")!, "ToDoList");
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