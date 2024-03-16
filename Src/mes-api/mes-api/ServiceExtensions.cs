using BOL.API.Service.Interfaces;
using BOL.API.Service.Services;

namespace bol.api;

public static class ServiceExtensione
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<IEntService, EntService>();
    }
}