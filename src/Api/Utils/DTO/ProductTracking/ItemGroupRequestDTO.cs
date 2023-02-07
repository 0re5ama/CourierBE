using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ItemGroupRequestDTO
{
    public string Name { get; set; }
    public EnStatus Status { get; set; }
}
