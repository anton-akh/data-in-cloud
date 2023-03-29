using EntityFrameworkCore.Testing.Common.Helpers;
using EntityFrameworkCore.Testing.Moq.Helpers;
using Microsoft.EntityFrameworkCore;
using StudentAccount.Api;
using StudentAccount.Dal;

namespace StudentAccount.IntegrationTests;

public class TestStartup : Startup
{
    public TestStartup(IConfiguration configuration)
        : base(configuration)
    {
    }

    protected override void ConfigureDb(IServiceCollection services)
    {
        var context = ConfigureDb<AppDbContext>().MockedDbContext;
        services.AddSingleton<AppDbContext>(c => context);
    }

    private IMockedDbContextBuilder<T> ConfigureDb<T>()
        where T : DbContext
    {
        var options = new DbContextOptionsBuilder<T>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var dbContextToMock = (T)Activator.CreateInstance(typeof(T), options);
        return new MockedDbContextBuilder<T>()
            .UseDbContext(dbContextToMock)
            .UseConstructorWithParameters(options);
    }
}