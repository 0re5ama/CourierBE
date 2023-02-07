using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Core.Interfaces;

public interface IAuthService
{
    Task<User> AuthenticateAsync(string Email, string Password);
    Task<string> RegisterAsync(User user);
    Task<string> VerifyEmailAsync(string userId, string code);
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserAsync(Guid Id);
}
