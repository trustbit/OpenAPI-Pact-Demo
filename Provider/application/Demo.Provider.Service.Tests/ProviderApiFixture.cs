namespace Demo.Provider.Service.Tests;

public class ProviderApiFixture : IDisposable
{
    private readonly IHost server;
    public Uri ServerUri { get; }

    public ProviderApiFixture()
    {
        ServerUri = new Uri("http://localhost:9223");
        server = Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseUrls(ServerUri.ToString());
                webBuilder.UseStartup<TestStartup>();
            })
            .Build();
        server.Start();
    }

    public void Dispose()
    {
        server.Dispose();
    }
}