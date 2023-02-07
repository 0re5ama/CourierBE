using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.ProductTracking;

public class PackageRequestDTO
{
    public string Name { get; set; }
    public EnStatus status { get; set; }
}
