using Microsoft.AspNetCore.Identity;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Exceptions.AuthExceptions;
using ProductTracking.Core.Interfaces;

namespace ProductTracking.Core.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly SignInManager<User> _signInManager;
    public AuthService(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public async Task<User> AuthenticateAsync(string UserName, string Password)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(UserName);
            var result = await _signInManager.PasswordSignInAsync(UserName, Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new InvalidLoginException();
            }

            return user;
        }
        catch (Exception ex)
        {
            throw new InvalidLoginException(ex);
        }
    }

    public Task<User> GetUserAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> RegisterAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<string> VerifyEmailAsync(string userId, string code)
    {
        throw new NotImplementedException();
    }
}
