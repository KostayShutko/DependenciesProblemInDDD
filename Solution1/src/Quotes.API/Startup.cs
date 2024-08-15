using Quotes.Application;
using Quotes.Infrastructure;
using System.Reflection;

namespace Quotes.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var executingAssembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(executingAssembly);

        services.AddApplicationServices();
        services.AddInfrastructureServices(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}