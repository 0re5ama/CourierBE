using ProductTracking.Api.Utils;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.CommonInterfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;
using ProductTracking.Core.Interfaces.Security;
using ProductTracking.Core.Interfaces.Settings;
using ProductTracking.Core.Services;
using ProductTracking.Core.Services.ProducTrackingServices;
using ProductTracking.Core.Services.Security;
using ProductTracking.Core.Services.Settings;
using ProductTracking.Infrastructure.Repositories;
using ProductTracking.Infrastructure.Services;

namespace ProductTracking.Api.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IExcellExportService, ExcellExportService>();





        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IModuleService, ModuleService>();
        services.AddScoped<IOfficeService, OfficeService>();

        services.AddScoped<IHeaderContactDetailService, HeaderContactDetailService>();
        services.AddScoped<IContainerService, ContainerService>();
        services.AddScoped<IItemGroupService, ItemGroupService>();
        services.AddScoped<IItemService, ItemService>();

        services.AddScoped<IConsignmentService, ConsignmentService>();
        services.AddScoped<ICheckpointService, CheckpointService>();
        services.AddScoped<IPackageService, PackageService>();


        // services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>)); // Add a logger
        services.AddTransient<IEmailSender, EmailSender>();


        return services;
    }
}
