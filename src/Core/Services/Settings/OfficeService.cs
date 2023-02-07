using ProductTracking.Core.Entities.Settings;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.Settings;

namespace ProductTracking.Core.Services.Settings;
public class OfficeService : IOfficeService
{
    private IUnitOfWork _uow;
    public OfficeService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<Office>> GetAsync()
    {
        return _uow.Repository<Office>().GetAll().ToList();

    }

    public async Task<Office> SaveAsync(Office office)
    {
        await _uow.Repository<Office>().InsertAsync(office);
        await _uow.SaveChangesAsync();
        return office;
    }

    public async Task<Office> UpdateAsync(Guid id, Office office)
    {
        var repo = _uow.Repository<Office>();
        repo.Update(office);
        await _uow.SaveChangesAsync();
        return office;
    }

    public async Task<Office> DeleteAsync(Guid id)
    {
        var repo = _uow.Repository<Office>();
        var office = repo.GetById(id);
        _uow.Repository<Office>()
            .Delete(office);
        await _uow.SaveChangesAsync();
        return office;
    }

    public async Task<Office> GetByIdAsync(Guid id)
    {
        return await _uow.Repository<Office>()
          .GetByIdAsync(id);
    }
}
