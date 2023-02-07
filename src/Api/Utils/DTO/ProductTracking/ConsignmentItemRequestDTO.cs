namespace ProductTracking.Api.DTO.ProductTracking;

public class ConsignmentItemRequestDTO
{
    public Guid? ConsignmentId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public string? Photo { get; set; }
    public string? Remarks { get; set; }
}
