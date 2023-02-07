namespace ProductTracking.Api.DTO;

public class UserDTO
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public UserDTO(string email, string userName)
    {
        Email = email;
        UserName = userName;
    }
}
