namespace ProductTracking.Api.DTO;

public class UserCredDTO
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserCredDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
