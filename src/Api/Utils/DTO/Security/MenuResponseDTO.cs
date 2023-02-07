namespace ProductTracking.Api.DTO.Security;

public class MenuResponseDTO
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public List<MenuRouteResponseDTO> Routes { get; set; }
}
