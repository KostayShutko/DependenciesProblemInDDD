using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Quotes.Domain;

public class ServiceDependencyProvider
{
    private static IHttpContextAccessor httpContextAccessor;

    public static void Configure(IHttpContextAccessor accessor)
    {
        httpContextAccessor = accessor;
    }

    public static IService GetService<IService>(Type type)
        where IService : class
    {
        return httpContextAccessor.HttpContext.RequestServices.GetService(type) as IService;
    }

}

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseServiceDependencyProvider(this IApplicationBuilder app)
    {
        var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

        ServiceDependencyProvider.Configure(httpContextAccessor);

        return app;
    }
}
