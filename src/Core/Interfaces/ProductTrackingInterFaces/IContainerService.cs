using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Core.Interfaces.ProductTrackingInterFaces;
public interface IContainerService
{
    public Task<List<Container>> GetAsync();
    public Task<Container> SaveAsync(Container container);
    public Task<Container> GetByIdAsync(Guid id);
    public Task<Container> UpdateAsync(Guid id, Container container);
    public Task<Container> DeleteAsync(Guid id);
    public Task<Container> SaveTransferAsync(Container container);
    public Task<List<Container>> GetcheckpointContainerAsync();


}
