using ProductTracking.Api.Utils;

namespace ProductTracking.Api.DTO.Security;

public class RoleListDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public string Status { get; set; }
    public string StatusText => Helper.GetStatusText(Status);
}
