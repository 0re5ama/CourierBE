using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ContainerResponseDTO
{
    public Guid Id { get; set; }
    public string? VechileNo { get; set; }
    public string? ContainerNo { get; set; }
    public string? DriverContactNo { get; set; }
    public EnContainerStatus Status { get; set; }
    public Guid SourceId { get; set; }
    public CheckpointDTO Source { get; set; }
    public Guid DestinationId { get; set; }
    public CheckpointDTO Destination { get; set; }
    public bool? IsReceived { get; set; }
    public Guid? TransferContainerId { get; set; }
    public ContainerDTO? TransferContainer { get; set; }
    public List<ContainerConsignmentResponseDTO> ContainerConsignments { get; set; }

}
