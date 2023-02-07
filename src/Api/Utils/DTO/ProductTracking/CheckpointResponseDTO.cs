using ProductTracking.Api.DTO.Security;

namespace ProductTracking.Api.DTO.ProductTracking;

public class CheckpointResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<UserResponseDTO> Users { get; set; }
}
