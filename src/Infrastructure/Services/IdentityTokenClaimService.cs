using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductTracking.Core.Configuration;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces;

namespace ProductTracking.Infrastructure.Services;
public class IdentityTokenClaimService : ITokenClaimsService
{
    private readonly UserManager<User> _userManager;
    private readonly AppConfig _config;

    public IdentityTokenClaimService(UserManager<User> userManager, IOptions<AppConfig> config)
    {
        _userManager = userManager;
        _config = config.Value;
    }

    public async Task<string> GetTokenAsync(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_config.ApiKey);
        //var user = await _userManager.FindByEmailAsync(email);
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email) };
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        claims.Add(new Claim("UserId", user.Id.ToString()));
        claims.Add(new Claim("UserName", user.Email));
        claims.Add(new Claim("Name", user.Name));
        claims.Add(new Claim("CheckpointId", user.CheckpointId.ToString()));
        //claims.Add(new Claim("Roles", user.UserRole));


        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _config.Issuer,
            Audience = _config.Audience,
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
