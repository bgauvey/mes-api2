using BOL.API.Service.Interfaces;
using BOL.API.Service.Interfaces.Core;
using BOL.API.Service.Interfaces.Prod;
using BOL.API.Service.Interfaces.Security;
using BOL.API.Service.Interfaces.Utilization;
using BOL.API.Service.Services;
using BOL.API.Service.Services.Core;
using BOL.API.Service.Services.Prod;
using BOL.API.Service.Services.Security;
using BOL.API.Service.Services.Utilization;

namespace bol.api
{
    public static class ServiceExtensione
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Core Services
            services.AddScoped<IAttrService, AttrService>();
            services.AddScoped<IDocTypeService, DocTypeService>();
            services.AddScoped<IEmailattService, EmailattService>();
            services.AddScoped<IEntService, EntService>();
            services.AddScoped<IEntAttrService, EntAttrService>();
            services.AddScoped<IEntLinkService, EntLinkService>();
            services.AddScoped<IFileDescService, FileDescService>();
            services.AddScoped<IFileTypeService, FileTypeService>();
            services.AddScoped<ILanguageGrpService, LanguageGrpService>();
            services.AddScoped<IMailGrpService, MailGrpService>();
            services.AddScoped<IMailGrpMemberService, MailGrpMemberService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMgrDataConfigService, MgrDataConfigService>();
            services.AddScoped<IPredMsgService, PredMsgService>();
            services.AddScoped<IShiftService, ShiftService>();
            services.AddScoped<IShiftExcService, ShiftExcService>();
            services.AddScoped<IShiftSchedService, ShiftSchedService>();
            services.AddScoped<ISystemAttrService, SystemAttrService>();
            services.AddScoped<ISystemAttrGrpService, SystemAttrGrpService>();
            services.AddScoped<IUiButtonService, UiButtonService>();
            services.AddScoped<IUiButtonSetService, UiButtonSetService>();
            services.AddScoped<IUiConfigService, UiConfigService>();
            services.AddScoped<IUiConfigDefaultService, UiConfigDefaultService>();

            // EnProd Services
            services.AddScoped<IInventoryService, InventoryService>();

            //Prod Services
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemStateService, ItemStateService>();
            services.AddScoped<IItemGradeService, ItemGradeService>();
            services.AddScoped<IItemClassService, ItemClassService>();
            services.AddScoped<IItemReasService, ItemReasService>();
            services.AddScoped<IItemReasGrpService, ItemReasGrpService>();
            services.AddScoped<IItemReasGrpEntLinkService, ItemReasGrpEntLinkService>();
            services.AddScoped<IItemReasGrpClassLinkService, ItemReasGrpClassLinkService>();
            services.AddScoped<IItemClassAttrService, ItemClassAttrService>();
            services.AddScoped<IJobEventService, JobEventService>();
            services.AddScoped<IJobExecService, JobExecService>();
            services.AddScoped<IJobSchedExecService, JobSchedExecService>();
            services.AddScoped<IUomService, UomService>();
            services.AddScoped<IUomConvService, UomConvService>();

            //Security Services
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IGrpEntLinkService, GrpEntLinkService>();
            services.AddScoped<IGrpPrivLinkService, GrpPrivLinkService>();
            services.AddScoped<IPrivService, PrivService>();

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