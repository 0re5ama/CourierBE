using Microsoft.IdentityModel.Tokens;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Interfaces;

namespace ProductTracking.Api.Utils;

public class CurrentUserService : ICurrentUserService
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public Guid UserId => Guid.Parse(GetClaimValue("UserId"));
    public string UserName => GetClaimValue("UserName");
    //public Guid CheckpointId => Guid.Parse(GetClaimValue("CheckpointId"));
    public Guid CheckpointId => GetClaimValue("CheckpointId").IsNullOrEmpty() == true ? Guid.Empty : Guid.Parse(GetClaimValue("CheckpointId"));


    // public UserInfo UserInfo => !string.IsNullOrEmpty(GetClaimValue("LoginInfo")) ? EncryptionHelper.Decrypt<UserInfo>(GetClaimValue("LoginInfo")) : null;
    public User UserInfo => new User()
    {
        UserName = UserName,
        Name = GetClaimValue("Name"),
        Id = UserId,
        CheckpointId = CheckpointId,
    };

    private string GetClaimValue(string claimType)
    {
        return (bool)_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ? _httpContextAccessor.HttpContext?.User?.Claims.Single(c => c.Type == claimType).Value : string.Empty;
    }
}
