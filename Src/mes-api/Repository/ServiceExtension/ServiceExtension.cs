

using BOL.API.Repository.Interfaces.Cert;
using BOL.API.Repository.Interfaces.Core;
using BOL.API.Repository.Interfaces.EnProd;
using BOL.API.Repository.Interfaces.Generic;
using BOL.API.Repository.Interfaces.Prod;
using BOL.API.Repository.Interfaces.Security;
using BOL.API.Repository.Interfaces.Util;
using BOL.API.Repository.Repositories.Cert;
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
        },
        ServiceLifetime.Transient);

        // Add repositories
        // Core
        services.AddScoped<IAttrRepository, AttrRepository>();
        services.AddScoped<IAttrSetRepository, AttrSetRepository>();
        services.AddScoped<IDocTypeRepository, DocTypeRepository>();
        services.AddScoped<IEmailattRepository, EmailattRepository>();
        services.AddScoped<IEntAttrRepository, EntAttrRepository>();
        services.AddScoped<IEntFileRepository, EntFileRepository>();
        services.AddScoped<IEntLinkRepository, EntLinkRepository>();
        services.AddScoped<IEntRepository, EntRepository>();
        services.AddScoped<IFileDescRepository, FileDescRepository>();
        services.AddScoped<IFileTypeRepository, FileTypeRepository>();
        services.AddScoped<ILanguageGrpRepository, LanguageGrpRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IMailGrpRepository, MailGrpRepository>();
        services.AddScoped<IMailGrpMemberRepository, MailGrpMemberRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IMgrDataConfigRepository, MgrDataConfigRepository>();
        services.AddScoped<IPredMsgRepository, PredMsgRepository>();
        services.AddScoped<IShiftRepository, ShiftRepository>();
        services.AddScoped<IShiftExcRepository, ShiftExcRepository>();
        services.AddScoped<IShiftSchedRepository, ShiftSchedRepository>();
        services.AddScoped<ISystemAttrRepository, SystemAttrRepository>();
        services.AddScoped<ISystemAttrGrpRepository, SystemAttrGrpRepository>();
        services.AddScoped<IUiButtonRepository, UiButtonRepository>();
        services.AddScoped<IUiButtonSetRepository, UiButtonSetRepository>();
        services.AddScoped<IUiConfigRepository, UiConfigRepository>();
        services.AddScoped<IUiConfigDefaultRepository, UiConfigDefaultRepository>();

        // Cert
        services.AddScoped<ICertRepository, CertRepository>();

        // EnProd
        services.AddScoped<IItemInvRepository, ItemInvRepository>();
        services.AddScoped<IJobSpecRepository, JobSpecRepository>();
        services.AddScoped<IJobStepRepository, JobStepRepository>();
        services.AddScoped<IStorageExecRepository, StorageExecRepository>();

        // Generic
        services.AddScoped<IGenericRepository, GenericRepository>();

        // Prod
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemAttrRepository, ItemAttrRepository>();
        services.AddScoped<IItemConsRepository, ItemConsRepository>();
        services.AddScoped<IItemFileRepository, ItemFileRepository>();
        services.AddScoped<IItemProdRepository, ItemProdRepository>();
        services.AddScoped<IItemStateRepository, ItemStateRepository>();
        services.AddScoped<IItemGradeRepository, ItemGradeRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IJobEventRepository, JobEventRepository>();
        services.AddScoped<IJobExecRepository, JobExecRepository>();

        // Security
        services.AddScoped<IGrpNameRepository, GrpNameRepository>();
        services.AddScoped<IGrpEntLinkRepository, GrpEntLinkRepository>();
        services.AddScoped<IGrpPrivLinkRepository, GrpPrivLinkRepository>();
        services.AddScoped<IPrivRepository, PrivRepository>();
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

