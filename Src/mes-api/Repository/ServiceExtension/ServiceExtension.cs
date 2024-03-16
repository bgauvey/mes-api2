
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Interfaces.Generic;
using BOL.API.Repository.Interfaces.Security;
using BOL.API.Repository.Repositories.Core;
using BOL.API.Repository.Repositories.Generic;
using BOL.API.Repository.Repositories.Security;
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
        services.AddScoped<IGrpNameRepository, GrpNameRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<IUserGrpLinkRepository, UserGrpLinkRepository>();
        services.AddScoped<IUserNameRepository, UserNameRepository>();

        services.AddScoped<IAttrRepository, AttrRepository>();
        services.AddScoped<IAttrSetRepository, AttrSetRepository>();
        services.AddScoped<IEntAttrRepository, EntAttrRepository>();
        services.AddScoped<IEntFileRepository, EntFileRepository>();
        services.AddScoped<IEntLinkRepository, EntLinkRepository>();
        services.AddScoped<IEntRepository, EntRepository>();

        services.AddScoped<IGenericRepository, GenericRepository>();
        return services;
    }
}

