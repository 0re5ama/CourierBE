﻿namespace ProductTracking.Api.DTO;

public class UserRegisterDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public UserRegisterDTO(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }
}
