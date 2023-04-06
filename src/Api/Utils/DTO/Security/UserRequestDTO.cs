using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.Security;

public class UserRequestDTO
{
    public string? EmployeeId { get; set; }
    public EnStatus Status { get; set; }
    public string Email { get; set; }
    public string Contact { get; set; }
    public string UserName { get; set; }
    public Guid OfficeId { get; set; }
    public string Name { get; set; }
    public bool IsSuperAdmin { get; set; }
    public List<UserRoleRequestDTO>? Roles { get; set; }
    //public List<UserModuleFunctionRequestDTO> userModuleFunctions { get; set; } = new List<UserModuleFunctionRequestDTO>();

}

public class UserSaveRequestDTO : UserRequestDTO
{
    public string Password { get; set; }
}


public class UserUpdateRequestDTO : UserRequestDTO
{
    public string? Password { get; set; }
}

public class UserRoleRequestDTO
{
    public string Name { get; set; }
}


public class UserModuleFunctionRequestDTO
{
    public Guid moduleFunctionId { get; set; }

}
