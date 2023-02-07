using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Infrastructure.Data;
using ProductTracking.Infrastructure.Repositories;
using ProductTracking.Infrastructure.Services;

namespace ProductTracking.Infrastructure;
public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<ProductTrackingDbContext>(c =>
            c.UseSqlServer(configuration.GetConnectionString("DBConnection")));

        services.AddIdentity<User, Role>()
                   .AddEntityFrameworkStores<ProductTrackingDbContext>()
                                   .AddDefaultTokenProviders();

        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

        services.AddScoped(typeof(IUnitOfWork), u =>
        {
            var context = u.GetService<ProductTrackingDbContext>();
            return new UnitOfWork(context);
        });
    }
}
