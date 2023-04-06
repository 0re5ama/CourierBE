namespace ProductTracking.Api.DTO;

public class UserCredDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public UserCredDTO(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}
