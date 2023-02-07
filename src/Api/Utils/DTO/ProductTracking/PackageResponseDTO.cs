using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.ProductTracking;

public class PackageResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public EnStatus status { get; set; }
}
