using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ItemGroupResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EnStatus Status { get; set; }
}
