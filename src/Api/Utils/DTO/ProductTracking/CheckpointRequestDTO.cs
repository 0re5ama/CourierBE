namespace ProductTracking.Api.DTO.ProductTracking;

public class CheckpointRequestDTO
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<CheckPointUserRequestDTO> Users { get; set; }
}
