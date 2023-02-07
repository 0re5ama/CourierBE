using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Core.Interfaces.ProductTrackingInterFaces;
public interface IConsignmentService
{
    public Task<List<Consignment>> GetAsync();
    public Task<Consignment> SaveAsync(Consignment recipt);
    public Task<Consignment> GetByIdAsync(Guid id);
    public Task<Consignment> UpdateAsync(Guid id, Consignment recipt);
    public Task<Consignment> DeleteAsync(Guid id);
    public Task<List<Consignment>> GetRecentConsignmentAsync();
    public Task<List<Consignment>> GetSentConsignmentAsync();
    public Task<List<Consignment>> GetReceivedConsignmentAsync();
    public Task<List<ContainerConsignment>> GetContainerConsignmentAsync(Guid id);
    public Task<List<Consignment>> GetIncomingConsignmentAsync();
    public Task<List<Consignment>> GetOutgoingConsignmentAsync();
    public Task<List<Consignment>> GetPaidConsignmentAsync();
    public Task<List<Consignment>> GetConsignmentAtCheckpointsAsync();
    public Task<List<Consignment>> GetFilterConsignmentsAsync(int time);
    public Task<List<Consignment>> GetSuggestConsignmentsAsync(string param);
    public Task<List<Consignment>> GetCheckpointConsignmentsAsync();












}
