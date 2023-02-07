using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ConsignmentRequestDTO
{
    public Guid? Id { get; set; }
    public Guid? ContainerId { get; set; }
    public string ConsignmentNo { get; set; }
    public Guid StartingStationId { get; set; }
    public Guid? CurrentLocationId { get; set; }
    public DateTime ConsignmentDate { get; set; }
    public Guid DestinationId { get; set; }
    public string Consignee { get; set; }
    public string Telephone { get; set; }
    public string Description { get; set; }
    public Guid? PackageId { get; set; }
    public int? Quantity { get; set; }
    public decimal? FreightPrePayment { get; set; }
    public decimal? FreightDelivery { get; set; }
    public string CtnNo { get; set; }
    public decimal? Expense { get; set; }
    public string? CBM { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Tax { get; set; }
    public decimal? Freight { get; set; }
    public decimal? Advance { get; set; }
    public decimal? Value { get; set; }
    public decimal? Insurance { get; set; }
    public string? Prepayment { get; set; }
    public string? Payment { get; set; }
    public decimal? TotalAmount { get; set; }
    public string? TradeMode { get; set; }
    public string? Remarks { get; set; }
    public string? Signature { get; set; }
    public List<ConsignmentItemRequestDTO>? ConsignmentItems { get; set; }
    public EnConsignmentStatus? ConsignmentsStatus { get; set; }
    public int? PaymentAmount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public EnPaymentStatus? PaymentStatus { get; set; }
}
