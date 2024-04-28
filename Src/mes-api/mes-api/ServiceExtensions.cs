using BOL.API.Service.Interfaces;
using BOL.API.Service.Interfaces.Core;
using BOL.API.Service.Interfaces.Utilization;
using BOL.API.Service.Services;
using BOL.API.Service.Services.Core;
using BOL.API.Service.Services.Utilization;

namespace bol.api
{
    public static class ServiceExtensione
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            // Core Services
            services.AddScoped<IAttrService, AttrService>();
            services.AddScoped<IEntService, EntService>();
            services.AddScoped<IEntAttrService, EntAttrService>();
            services.AddScoped<IEntLinkService, EntLinkService>();
            services.AddScoped<ISystemAttrService, SystemAttrService>();

            // EnProd Services
            services.AddScoped<IInventoryService, InventoryService>();

            //Prod Services
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IJobExecService, JobExecService>();

            // Utilization Services
            services.AddScoped<IUtilExecService, UtilExecService>();
            services.AddScoped<IUtilStateService, UtilStateService>();
            services.AddScoped<IUtilReasGrpService, UtilReasGrpService>();
            services.AddScoped<IUtilLogService, UtilLogService>();
            services.AddScoped<IUtilReasService, UtilReasService>();
            services.AddScoped<IUtilReasLinkService, UtilReasLinkService>();
            services.AddScoped<IUtilRawReasService, UtilRawReasService>();
        }
    }
}