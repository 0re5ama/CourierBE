namespace ProductTracking.Api.DTO.ProductTracking;

public class ConsignmentDTO
{
    public Guid Id { get; set; }
    public string ConsignmentNo { get; set; }
    public Guid StartingStationId { get; set; }
    public Guid? CurrentLocationId { get; set; }
    public DateTime ConsignmentDate { get; set; }
    public Guid DestinationId { get; set; }
    public string Consignee { get; set; }
    public string Telephone { get; set; }
    public string Description { get; set; }
    public int? Quantity { get; set; }
    public Decimal CTNNO { get; set; }
    public Decimal? Expense { get; set; }
    public Decimal? CBM { get; set; }
    public Decimal? Weight { get; set; }
    public Decimal? Tax { get; set; }
    public Decimal? Freight { get; set; }
    public Decimal? Advance { get; set; }
    public Decimal? BillCharge { get; set; }
    public Decimal? Value { get; set; }
    public Decimal? Insurance { get; set; }
    public Decimal? PaymentAmount { get; set; }
    public int? PaymentMethod { get; set; }
    public DateTime? PaymentDate { get; set; }
    public List<ConsignmentItemListDTO> ConsignmentItems { get; set; }
}
