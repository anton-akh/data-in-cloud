using Microsoft.AspNetCore.TestHost;
using StudentAccount.Dal;

namespace StudentAccount.IntegrationTests;

public class BaseTest : IDisposable
{
    protected IHost Host;

    private IHostBuilder _server;
    protected AppDbContext AppDbContext;
    public BaseTest()
    {
    }

    public void Dispose()
    {
        StopServer();
        Host?.Dispose();
        AppDbContext?.Dispose();
    }

    public virtual HttpClient GetClient()
    {
        Host = _server.Start();
        AppDbContext = Host.Services.GetService(typeof(AppDbContext)) as AppDbContext;
        return Host.GetTestClient();
    }

    private void StopServer()
    {
        Host?.StopAsync().GetAwaiter().GetResult();
    }

    protected BaseTest InitTestServer()
    {
        _server = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.UseStartup<TestStartup>();
            });
        return this;
    }
}