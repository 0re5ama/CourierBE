using System.ComponentModel.DataAnnotations.Schema;
using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Core.Entities.TrackingAggregate;
public class Consignment : BaseEntity
{
    public Guid? ContainerId { get; set; }
    public Container? Container { get; set; }
    public string ConsignmentNo { get; set; }
    public Guid StartingStationId { get; set; }
    public Checkpoint StartingStation { get; set; }
    public DateTime ConsignmentDate { get; set; }
    public Guid? CurrentLocationId { get; set; }
    public Checkpoint? CurrentLocation { get; set; }
    public Guid DestinationId { get; set; }
    public Checkpoint Destination { get; set; }
    public string Consignee { get; set; }
    public string Telephone { get; set; }
    public string Description { get; set; }
    public Guid? PackageId { get; set; }
    public Package? Package { get; set; }
    public int? Quantity { get; set; }
    public string? CtnNo { get; set; }
    public decimal? PackingFee { get; set; }
    public decimal? Volume { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Tax { get; set; }
    public decimal? Freight { get; set; }
    // public decimal? FreightPrePayment { get; set; }
    public decimal? LocalFreight { get; set; }
    public decimal? freightDelivery => TotalAmount - Advance;
    public decimal? Advance { get; set; }
    public decimal? BillCharge { get; set; }
    public decimal? Value { get; set; }
    public  decimal? Insurance { get; set; }
    // public string? Prepayment { get; set; }
    public int? PaymentMethod { get; set; }
    public string? Payment { get; set; }
    public decimal? TotalAmount => PackingFee + Freight + Tax + BillCharge + LocalFreight + Insurance;
    public string? TradeMode { get; set; }
    public string? Remarks { get; set; }
    public string? Signature { get; set; }
    public List<ConsignmentItem>? ConsignmentItems { get; set; }
    public EnConsignmentStatus? ConsignmentsStatus { get; set; }
    public decimal? PaymentAmount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public EnPaymentStatus? PaymentStatus { get; set; }

}
