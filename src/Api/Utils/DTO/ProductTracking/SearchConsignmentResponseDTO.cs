using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.DTO.ProductTracking;

public class SearchConsignmentResponseDTO
{
    public Guid? Id { get; set; }
    public ContainerDTO Container { get; set; }
    public Guid? ContainerId { get; set; }
    public Guid? ConsignmentId { get; set; }
    public string? Remarks { get; set; }
    public EnRecivedStatus? RecivedStatus { get; set; }
    public DateTime? RecivedDate { get; set; }
    public DateTime? EntryDate { get; set; }
}
