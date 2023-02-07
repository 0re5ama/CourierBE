using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ConsignmentListDTO
{
    public Guid Id { get; set; }
    public Guid? ContainerId { get; set; }
    public ContainerDTO Container { get; set; }
    public string ConsignmentNo { get; set; }
    public Guid StartingStationId { get; set; }
    public Guid? CurrentLocationId { get; set; }
    public DateTime ConsignmentDate { get; set; }
    public Guid DestinationId { get; set; }
    public string Consignee { get; set; }
    public string Telephone { get; set; }
    public string Description { get; set; }
    public int? Quantity { get; set; }
    public decimal? FreightPrePayment { get; set; }
    public decimal? freightDelivery { get; set; }
    public string CtnNo { get; set; }
    public string? Expense { get; set; }
    public string? CBM { get; set; }
    public string? Weight { get; set; }
    public string? Tax { get; set; }
    public string? Freight { get; set; }
    public string? Advance { get; set; }
    public string? Value { get; set; }
    public string? Insurance { get; set; }
    public EnConsignmentStatus? ConsignmentsStatus { get; set; }
    public int? PaymentAmount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public EnPaymentStatus? PaymentStatus { get; set; }
    public string PaymentStatusName => PaymentStatus.ToString();
    public List<ConsignmentItemListDTO> ConsignmentItems { get; set; }

}
