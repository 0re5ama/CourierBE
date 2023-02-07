namespace ProductTracking.Api.DTO.Security;

public class ApplicationResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public List<ModuleResponseDTO>? Modules { get; set; }
}
