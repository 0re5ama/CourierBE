namespace ProductTracking.Api.DTO.ProductTracking;

public class ConsignmentItemListDTO
{
    public Guid Id { get; set; }
    public Guid? ConsignmentId { get; set; }
    public string ItemName { get; set; }
    // public Guid ItemId { get; set; }
    public ItemDTO Item { get; set; }
    public int Quantity { get; set; }
    public string? Photo { get; set; }
    public string? Remarks { get; set; }
}
