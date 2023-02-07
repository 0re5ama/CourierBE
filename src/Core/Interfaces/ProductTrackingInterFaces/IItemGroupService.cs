using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Core.Interfaces.ProductTrackingInterFaces;
public interface IItemGroupService
{
    public Task<List<ItemGroup>> GetAsync();
    public Task<ItemGroup> SaveAsync(ItemGroup item);
    public Task<ItemGroup> GetByIdAsync(Guid id);
    public Task<ItemGroup> UpdateAsync(Guid id, ItemGroup item);
    public Task<ItemGroup> DeleteAsync(Guid id);
}
