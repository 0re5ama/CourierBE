using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.DTO.ProductTracking;

public class PaymentListDTO
{
    public Guid Id { get; set; }
    public Guid ConsignmentId { get; set; }
    public int? PaymentAmount { get; set; }
    public DateTime? Date { get; set; }
    public EnPaymentStatus Status { get; set; }
}
