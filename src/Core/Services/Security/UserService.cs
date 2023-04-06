using System.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Enums.Security;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.Security;

namespace ProductTracking.Core.Services.Security;
public class UserService : IUserService
{
    private IUnitOfWork _uow;
    private UserManager<User> _userManager;
    private RoleManager<User> _roleManager;
    private readonly ICurrentUserService _currentUserService;

    public UserService(IUnitOfWork uow, UserManager<User> userManager, ICurrentUserService currentUserService)
    {
        _uow = uow;
        _userManager = userManager;
        _currentUserService = currentUserService;
    }

    public Guid? GetCurrentUserId()
    {
        try
        {
            Guid UserId = _currentUserService.UserId;
            return UserId;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<User>> GetAsync()
    {
        var userRepo = _uow.Repository<User>();
        return userRepo.GetAll().ToList();
    }

    public async Task<User> SaveAsync(User user)
    {
        try
        { 
            var roles = user.Roles.Select(x => x.Name).ToList();
              user.Roles.Clear();
            var result = await _userManager.CreateAsync(user, user.Password);
            //.ContinueWith((t) => _userManager.AddToRolesAsync(user, roles));
            var rolesSaved = await _userManager.AddToRolesAsync(user, roles);

            return user;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<User> GetAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString("D"));
        var umfRepo = _uow.Repository<UserModuleFunction>();
        var ModuleRepo = _uow.Repository<Module>();
        var ApplicationRepo = _uow.Repository<Application>();
        var roles = await _userManager.GetRolesAsync(user);
        user.Roles = roles.Select(x => new Role() { Name = x }).ToList();
        user.UserModuleFunctions = umfRepo.GetAll(x => x.UserId == id, null, x => x.ModuleFunction).ToList();
        foreach (var modfn in user.UserModuleFunctions)
        {
            modfn.ModuleFunction.Module = ModuleRepo.GetAll(x => x.Id == modfn.ModuleFunction.ModuleId, null, x => x.Application).FirstOrDefault();
        }
        return user;
    }

    public async Task<User> UpdateAsync(Guid id, User user)
    {
        var updatedUser = await _userManager.FindByIdAsync(id.ToString("D"));
        //var umfRepo = _uow.Repository<UserModuleFunction>();
        //var dbumf = umfRepo.GetAll(x => x.UserId == id).ToList();
        //updatedUser.UserModuleFunctions = dbumf;

        if (updatedUser != null)
        {
            updatedUser.UserName = user.UserName;
            /*
            List<UserModuleFunction> delMFs = dbumf
              .Where(x => !user.UserModuleFunctions.Any(y => y.ModuleFunctionId == x.ModuleFunctionId))
              .ToList();
            List<UserModuleFunction> addMFs = user.UserModuleFunctions
                .Where(x => !dbumf.Any(y => y.ModuleFunctionId == x.ModuleFunctionId))
                .ToList();
            addMFs.ForEach(x => x.UserId = id);
            delMFs.ForEach(x => umfRepo.Delete(x));
            addMFs.ForEach(x => umfRepo.Insert(x));
            */
            await _userManager.UpdateAsync(updatedUser);
            await _uow.SaveChangesAsync();

            return user;
        }
        else
        {
            return user;
        }
    }

    public async Task<User> DeleteAsync(Guid id)
    {
        var deleteUser = await _userManager.FindByIdAsync(id.ToString("D"));
        await _userManager.DeleteAsync(deleteUser);
        return deleteUser;
    }

    public async Task<List<User>> GetOfficeUserAsync(Guid id)
    {
        //var organization = await _uow.Repository<Office>().GetByIdAsync(id);
        var userRepo = _uow.Repository<User>();
        return userRepo.GetAll(x => x.OfficeId == id).ToList();
    }

    public async Task<User> GetTest(Guid id)
    {
        List<string> permissions = new List<string>();
        var user = await _userManager.FindByIdAsync(id.ToString("D"));
        var UserRepo = _uow.Repository<User>();
        var ModuleRepo = _uow.Repository<Module>();
        var ApplicationRepo = _uow.Repository<Application>();
        user = UserRepo.GetAll(x => x.Id == id, null, x => x.Roles).SingleOrDefault();

        foreach (var role in user.Roles)
        {
            var rmf = _uow.Repository<RoleModuleFunction>().GetAll(x => x.RoleId == role.Id).Select(x => x.ModuleFunctionId).ToList();
            foreach (var mod in rmf)
            {
                List<EnFunction> fun = _uow.Repository<ModuleFunction>().GetAll(x => x.ModuleId == mod).Select(x => x.FunctionId).ToList();
                var name = _uow.Repository<Module>().GetAll(x => x.Id == mod).Select(x => x.Name).SingleOrDefault();

                foreach (Enum per in fun)
                {
                    permissions.Add(per + name);
                }
            }
        }
        return user;
    }

    public async Task<List<string>> GetUserPermissions(Guid? UserId)
    {
        if (UserId == null) UserId = GetCurrentUserId();
        try
        {
            List<string> permissions = new List<string>();
            var user = await _userManager.FindByIdAsync(UserId.ToString());
            var UserRepo = _uow.Repository<User>();
            var ModuleRepo = _uow.Repository<Module>();
            var ApplicationRepo = _uow.Repository<Application>();
            user = await UserRepo.GetAll(x => x.Id == UserId, null, x => x.Roles).SingleOrDefaultAsync();

            foreach (var role in user.Roles)
            {
                var rmf = _uow.Repository<RoleModuleFunction>().GetAll(x => x.RoleId == role.Id).Select(x => x.ModuleFunctionId).ToListAsync();
                foreach (var mod in await rmf)
                {
                    List<EnFunction> fun = await _uow.Repository<ModuleFunction>().GetAll(x => x.ModuleId == mod).Select(x => x.FunctionId).ToListAsync();
                    var name = _uow.Repository<Module>().GetAll(x => x.Id == mod).Select(x => x.Name).SingleOrDefaultAsync();

                    foreach (Enum per in fun)
                    {
                        permissions.Add(per + await name);
                    }
                }
            }
            return permissions;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
