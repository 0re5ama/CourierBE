using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.Security;

namespace ProductTracking.Core.Services.Security;
public class ModuleService : IModuleService
{
    private readonly IUnitOfWork _uow;
    public ModuleService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<Module>> GetAsync()
    {
        var repo = _uow.Repository<Module>();
        return repo.GetAll().ToList();
    }

    public async Task<List<Module>> GetAsync(Guid ApplicationId)
    {
        var repo = _uow.Repository<Module>();
        return repo.GetAll(x => x.ApplicationId == ApplicationId, null, x => x.Functions).ToList();
    }

    public async Task<List<Application>> GetApplicationsAsync()
    {
        var repo = _uow.Repository<Application>();
        return repo.GetAll().ToList();
    }

    public async Task<List<Application>> GetApplicationsWithModulesAsync()
    {
        var repo = _uow.Repository<Application>();
        var apps = repo.GetAll().ToList();
        var modRepo = _uow.Repository<Module>();
        apps.ForEach(app =>
        {
            app.Modules = modRepo
                .GetAll(
                    mod => mod.ApplicationId == app.Id,
                    null,
                    x => x.Functions
                ).ToList();
        });
        return apps;
    }
}
