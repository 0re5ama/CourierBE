using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Core.Interfaces.Security;
public interface IModuleService
{
    public Task<List<Module>> GetAsync();
    public Task<List<Module>> GetAsync(Guid ApplicationId);
    public Task<List<Application>> GetApplicationsAsync();
    public Task<List<Application>> GetApplicationsWithModulesAsync();

}
