

using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Interfaces.EnProd;
using BOL.API.Repository.Interfaces.Generic;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Repository.Interfaces.Security;
using BOL.API.Repository.Interfaces.Util;
using BOL.API.Repository.Repositories.Core;
using BOL.API.Repository.Repositories.EnProd;
using BOL.API.Repository.Repositories.Generic;
using BOL.API.Repository.Repositories.Prod;
using BOL.API.Repository.Repositories.Security;
using BOL.API.Repository.Repositories.Util;
using BOL.API.Repository.Util;
using Microsoft.EntityFrameworkCore;

namespace BOL.API.Repository.ServiceExtension;

public static class ServiceExtension
{
    public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FactelligenceContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        // Add repositories
        // Core
        services.AddScoped<IAttrRepository, AttrRepository>();
        services.AddScoped<IAttrSetRepository, AttrSetRepository>();
        services.AddScoped<IEntAttrRepository, EntAttrRepository>();
        services.AddScoped<IEntFileRepository, EntFileRepository>();
        services.AddScoped<IEntLinkRepository, EntLinkRepository>();
        services.AddScoped<IEntRepository, EntRepository>();

        // EnProd
        services.AddScoped<IItemInvRepository, ItemInvRepository>();
        services.AddScoped<IStorageExecRepository, StorageExecRepository>();

        // Generic
        services.AddScoped<IGenericRepository, GenericRepository>();

        // Prod
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IJobExecRepository, JobExecRepository>();

        // Security
        services.AddScoped<IGrpNameRepository, GrpNameRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<IUserGrpLinkRepository, UserGrpLinkRepository>();
        services.AddScoped<IUserNameRepository, UserNameRepository>();

        //Utilization
        services.AddScoped<IUtilExecRepository, UtilExecRepository>();
        services.AddScoped<IUtilStateRepository, UtilStateRepository>();
        services.AddScoped<IUtilReasGrpRepository, UtilReasGrpRepository>();
        services.AddScoped<IUtilLogRepository, UtilLogRepository>();
        services.AddScoped<IUtilReasRepository, UtilReasRepository>();
        services.AddScoped<IUtilReasLinkRepository, UtilReasLinkRepository>();
        services.AddScoped<IUtilRawReasRepository, UtilRawReasRepository>();

        return services;
    }
}

