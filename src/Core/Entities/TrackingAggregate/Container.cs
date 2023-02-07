using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Core.Entities.TrackingAggregate;
public class Container : BaseEntity
{
    public string? VechileNo { get; set; }
    public string? ContainerNo { get; set; }
    public EnContainerStatus Status { get; set; }
    public string? DriverContactNo { get; set; }
    public Guid SourceId { get; set; }
    public Checkpoint Source { get; set; }
    public Guid DestinationId { get; set; }
    public Checkpoint Destination { get; set; }
    public bool? IsReceived { get; set; }
    public Guid? TransferContainerId { get; set; }
    public Container? TransferContainer { get; set; }
    public List<ContainerConsignment>? ContainerConsignments { get; set; }


}
