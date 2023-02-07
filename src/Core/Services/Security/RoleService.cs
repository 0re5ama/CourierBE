using Microsoft.AspNetCore.Identity;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.Security;

namespace ProductTracking.Core.Services.Security;
public class RoleService : IRoleService
{
    private RoleManager<Role> _roleManager;
    private IUnitOfWork _uow;
    public RoleService(RoleManager<Role> roleManager, IUnitOfWork uow)
    {
        _roleManager = roleManager;
        _uow = uow;
    }

    public async Task<Role> GetAsync(Guid id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString("D"));
        var rmfRepo = _uow.Repository<RoleModuleFunction>();
        var ModuleRepo = _uow.Repository<Module>();
        var ApplicationRepo = _uow.Repository<Application>();
        role.RoleModuleFunctions = rmfRepo.GetAll(x => x.RoleId == id, null, x => x.ModuleFunction).ToList();
        foreach (var modfn in role.RoleModuleFunctions)
        {
            modfn.ModuleFunction.Module = ModuleRepo.GetAll(x => x.Id == modfn.ModuleFunction.ModuleId, null, x => x.Application).FirstOrDefault();

        }
        return role;
    }

    public async Task<List<Role>> GetAsync()
    {
        return _roleManager.Roles.ToList();
    }
    #region Save
    /// <summary>
    /// Save Role
    /// </summary>
    /// <param name="role"></param>
    /// <returns>Saved Data</returns>
    public async Task<Role> SaveAsync(Role role)
    {
        role.FromDate = DateTime.Now;
        await _roleManager.CreateAsync(role);
        await _uow.SaveChangesAsync();
        return role;
    }
    #endregion
    #region Update
    public async Task<Role> UpdateAsync(Guid id, Role role)
    {
        var updatedrole = await _roleManager.FindByIdAsync(id.ToString("D"));
        var rmfRepo = _uow.Repository<RoleModuleFunction>();

        var dbrmf = rmfRepo.GetAll(x => x.RoleId == id).ToList();
        updatedrole.RoleModuleFunctions = dbrmf;
        try
        {
            if (updatedrole != null)
            {
                updatedrole.Name = role.Name;
                updatedrole.Desc = role.Desc;
                updatedrole.Status = role.Status;


                List<RoleModuleFunction> delMFs = dbrmf
                    .Where(x => !role.RoleModuleFunctions.Any(y => y.ModuleFunctionId == x.ModuleFunctionId))
                    .ToList();
                List<RoleModuleFunction> addMFs = role.RoleModuleFunctions
                    .Where(x => !dbrmf.Any(y => y.ModuleFunctionId == x.ModuleFunctionId))
                    .ToList();
                addMFs.ForEach(x => x.RoleId = id);
                delMFs.ForEach(x => rmfRepo.Delete(x));
                addMFs.ForEach(x => rmfRepo.Insert(x));

                await _roleManager.UpdateAsync(updatedrole);
                await _uow.SaveChangesAsync();
                return role;
            }
            else
            {
                return role;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Delete
    public async Task<Role> DeleteAsync(Guid id)
    {
        var deletedRole = await _roleManager.FindByIdAsync(id.ToString("D"));
        await _roleManager.DeleteAsync(deletedRole);
        return deletedRole;
    }
    #endregion
}
