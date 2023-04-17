using Demo.Provider.Service.Tests.Middleware;

namespace Demo.Provider.Service.Tests;

public class TestStartup
{
    public TestStartup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddApplicationPart(typeof(Startup).Assembly)
            .AddControllersAsServices();
        Startup.ConfigureApplication(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ProviderStateMiddleware>();
        app.UseDeveloperExceptionPage();
        Startup.UseRouting(app);
    }
}