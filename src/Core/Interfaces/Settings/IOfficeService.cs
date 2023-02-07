using ProductTracking.Core.Entities.Settings;

namespace ProductTracking.Core.Interfaces.Settings;
public interface IOfficeService
{
    public Task<Office> SaveAsync(Office office);
    public Task<List<Office>> GetAsync();
    public Task<Office> GetByIdAsync(Guid id);
    public Task<Office> UpdateAsync(Guid id, Office office);
    public Task<Office> DeleteAsync(Guid id);



}
