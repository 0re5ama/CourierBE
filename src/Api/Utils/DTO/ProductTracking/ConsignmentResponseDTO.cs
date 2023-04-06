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
    public decimal? LocalFreight { get; set; }
    public decimal? FreightDelivery { get; set; }
    public string? CtnNo { get; set; }
    public string? PackingFee { get; set; }
    public string? Volume { get; set; }
    public string? Weight { get; set; }
    public string? Tax { get; set; }
    public string? Freight { get; set; }
    public decimal? Advance { get; set; }
    public decimal? BillCharge { get; set; }
    public decimal? Value { get; set; }
    public decimal? Insurance { get; set; }
    public decimal? Prepayment { get; set; }
    public decimal? Payment { get; set; }
    public decimal? TotalAmount { get; set; }
    public int? PaymentMethod { get; set; }
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
