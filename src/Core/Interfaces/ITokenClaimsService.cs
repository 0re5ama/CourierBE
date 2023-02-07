using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Core.Interfaces;
public interface ITokenClaimsService
{
    Task<string> GetTokenAsync(User user);
}
