namespace ProductTracking.Api.DTO.Security;

public class MenuResponseDTO
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public string? Path { get; set; }
    public string? Component { get; set; }

    public List<MenuResponseDTO>? Routes { get; set; }
}
