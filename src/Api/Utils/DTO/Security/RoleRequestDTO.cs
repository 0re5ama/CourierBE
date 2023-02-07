using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.Security;

public class RoleRequestDTO
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public EnStatus Status { get; set; }
    public List<RoleModuleFunctionRequestDTO> RoleModuleFunctions { get; set; } = new List<RoleModuleFunctionRequestDTO>();

}

public class RoleModuleFunctionRequestDTO
{
    public Guid ModuleFunctionId { get; set; }

}

