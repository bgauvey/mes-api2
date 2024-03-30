using BOL.API.Service.Interfaces;
using BOL.API.Service.Services;

namespace bol.api
{
    public static class ServiceExtensione
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IEntService, EntService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IJobExecService, JobExecService>();
            services.AddScoped<IUtilizationService, UtilizationService>();
            services.AddScoped<IUtilStateService, UtilStateService>();
            services.AddScoped<IUtilReasGrpService, UtilReasGrpService>();
        }
    }
}