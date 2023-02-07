using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ContainerConsignmentRequestDTO
{
    public Guid? Id { get; set; }
    public Guid? ContainerId { get; set; }
    public Guid? ConsignmentId { get; set; }
    public string? Remarks { get; set; }
    public EnRecivedStatus? RecivedStatus { get; set; }
    public DateTime? RecivedDate { get; set; }
}
