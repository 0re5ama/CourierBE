using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ConsignmentResponseDTO
{
    public Guid Id { get; set; }
    public Guid? ContainerId { get; set; }
    public ContainerDTO Container { get; set; }
    public string ConsignmentNo { get; set; }
    public Guid StartingStationId { get; set; }
    public CheckpointDTO StartingStation { get; set; }
    public DateTime ConsignmentDate { get; set; }
    public Guid? CurrentLocationId { get; set; }
    public CheckpointDTO CurrentLocation { get; set; }
    public Guid DestinationId { get; set; }
    public CheckpointDTO Destination { get; set; }
    public string Consignee { get; set; }
    public string Telephone { get; set; }
    public string Description { get; set; }
    public Guid PackageId { get; set; }
    public PackageDTO Package { get; set; }
    public int? Quantity { get; set; }
    public decimal? FreightPrePayment { get; set; }
    public decimal? FreightDelivery { get; set; }
    public string CtnNo { get; set; }
    public string? Expense { get; set; }
    public string? CBM { get; set; }
    public string? Weight { get; set; }
    public string? Tax { get; set; }
    public string? Freight { get; set; }
    public string? Advance { get; set; }
    public string? Value { get; set; }
    public string? Insurance { get; set; }
    public string? Prepayment { get; set; }
    public string? Payment { get; set; }
    public string? TotalAmount { get; set; }
    public string? TradeMode { get; set; }
    public string? Remarks { get; set; }
    public string? Signature { get; set; }
    public List<ConsignmentItemResponseDTO>? ConsignmentItems { get; set; }
    public EnConsignmentStatus? ConsignmentsStatus { get; set; }
    public int MyProperty { get; set; }
    public int? PaymentAmount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public EnPaymentStatus? PaymentStatus { get; set; }
    public string PaymentStatusName => PaymentStatus.ToString();
}
