using ProductTracking.Core.Enums;
using ProductTracking.Core.Enums.Security;

namespace ProductTracking.Api.DTO.Security;

public class RoleResponseDTO
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public EnStatus Status { get; set; }
    public List<RoleModuleFunctionResponseDTO> RoleModuleFunctions { get; set; } = new List<RoleModuleFunctionResponseDTO>();

}

public class RoleModuleFunctionResponseDTO
{
    public Guid ModuleFunctionId { get; set; }
    public Role_ModuleFunctionResponseDTO moduleFunction { get; set; }


}
public class Role_ModuleFunctionResponseDTO
{
    public Guid Id { get; set; }
    public RoleModuleResponseDTO Module { get; set; }
    public EnFunction FunctionId { get; set; }
    public string FunctionName => FunctionId.ToString();
}



public class RoleModuleResponseDTO
{
    public Guid Id { get; set; }

    public RoleApplicationResponseDTO Application { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


public class RoleApplicationResponseDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Desc { get; set; }
}
