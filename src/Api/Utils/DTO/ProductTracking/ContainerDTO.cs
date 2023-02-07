namespace ProductTracking.Api.DTO.ProductTracking;

public class ContainerDTO
{
    public Guid Id { get; set; }
    public string? VechileNo { get; set; }
    public Guid? SourceId { get; set; }
    public CheckpointDTO Source { get; set; }
    public Guid? DestinationId { get; set; }
    public CheckpointDTO Destination { get; set; }
    public string? ContainerNo { get; set; }
}
