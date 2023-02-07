using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ItemListDTO
{
    public Guid Id { get; set; }
    public Guid? ItemGroupId { get; set; }
    public ItemGroupDTO ItemGroup {get; set;}
    public string Name { get; set; }
    public string NameShort { get; set; }
    public EnStatus Status { get; set; }
    public string StatusName => Status.ToString();
}
