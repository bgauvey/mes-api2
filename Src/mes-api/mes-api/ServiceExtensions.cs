using BOL.API.Service.Interfaces;
using BOL.API.Service.Interfaces.Utilization;
using BOL.API.Service.Services;
using BOL.API.Service.Services.Utilization;

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
            services.AddScoped<IUtilExecService, UtilExecService>();
            services.AddScoped<IUtilStateService, UtilStateService>();
            services.AddScoped<IUtilReasGrpService, UtilReasGrpService>();
            services.AddScoped<IUtilLogService, UtilLogService>();
            services.AddScoped<IUtilReasService, UtilReasService>();
        }
    }
}