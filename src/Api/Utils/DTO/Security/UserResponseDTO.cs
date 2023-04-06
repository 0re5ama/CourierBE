using ProductTracking.Core.Enums;
using ProductTracking.Core.Enums.Security;

namespace ProductTracking.Api.DTO.Security;

public class UserResponseDTO
{
    public Guid Id { get; set; }
    public string? EmployeeId { get; set; }
    public Guid? CheckpointId { get; set; }
    public EnStatus Status { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsSuperAdmin { get; set; }
    public Guid OfficeId { get; set; }
    public List<UserRoleResponseDTO> Roles { get; set; }
    public List<UserModuleFunctionResponseDTO> UserModuleFunctions { get; set; } = new List<UserModuleFunctionResponseDTO>();

}

public class UserRoleResponseDTO
{

    // public Guid RoleId { get; set; }
    // public user_RoleResponseDTO Role { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }


}

public class user_RoleResponseDTO
{
    public Guid Id { get; set; }
    public string name { get; set; }
}

public class UserModuleFunctionResponseDTO
{
    public Guid ModuleFunctionId { get; set; }
    public User_ModuleFunctionResponseDTO moduleFunction { get; set; }


}

public class User_ModuleFunctionResponseDTO
{
    public Guid Id { get; set; }
    public UserModuleResponseDTO Module { get; set; }
    public EnFunction FunctionId { get; set; }
    public string FunctionName => FunctionId.ToString();

}

public class UserModuleResponseDTO
{
    public Guid Id { get; set; }

    public UserApplicationResponseDTO Application { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


public class UserApplicationResponseDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Desc { get; set; }
}
