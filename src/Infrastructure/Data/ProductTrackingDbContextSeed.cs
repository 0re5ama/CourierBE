using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Infrastructure.Data;
public class ProductTrackingDbContextSeed
{
    public static async Task SeedAsync(ProductTrackingDbContext financeDbContext,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        ILogger logger,
        int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (financeDbContext.Database.IsSqlServer())
            {
                financeDbContext.Database.Migrate();
            }

            const string adminUserName = "admin@admin.com";
            const string adminRoleName = "Admin";
            const string adminName = "Admin User";

            await roleManager.CreateAsync(new Role("Admin", "Administrator", "187cda14-9844-42e7-99ba-b8d4f0d59c3a"));
            var adminUser = new User("d62ef199-acc5-42e4-81b7-da29f88c712b", adminUserName, adminUserName, adminName, "187cda14-9844-42e7-99ba-b8d4f0d59c3a",new DateTime(2022, 8, 19, 0, 0, 0, DateTimeKind.Utc));
            await userManager.CreateAsync(adminUser, "Super@dmin123");

            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, adminRoleName);


        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(financeDbContext, userManager, roleManager, logger, retryForAvailability);
            throw;
        }
    }
}
