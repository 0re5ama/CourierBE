using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Core.Interfaces;
public interface ICurrentUserService
{
    Guid UserId { get; }
    string UserName { get; }
    User UserInfo { get; }


}
