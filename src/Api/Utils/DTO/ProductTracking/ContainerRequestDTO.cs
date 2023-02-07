using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ContainerRequestDTO
{  
    public Guid? Id { get; set; }    
    public string? VechileNo { get; set; }
    public string? ContainerNo { get; set; }
    public EnContainerStatus Status { get; set; }
    public string? DriverContactNo { get; set; }
    public Guid SourceId { get; set; }
    public Guid DestinationId { get; set; }
    public bool? IsReceived { get; set; }
    public Guid? TransferContainerId { get; set; }
    public List<ContainerConsignmentRequestDTO>? ContainerConsignments { get; set; } 
}
