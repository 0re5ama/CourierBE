using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Core.Interfaces.Security;
public interface IUserService
{
    public Guid? GetCurrentUserId();

    public Task<List<User>> GetAsync();

    public Task<User> SaveAsync(User user);

    public Task<User> GetAsync(Guid id);

    public Task<User> GetTest(Guid id);

    public Task<User> UpdateAsync(Guid id, User user);

    public Task<User> DeleteAsync(Guid id);

    public Task<List<User>> GetOfficeUserAsync(Guid id);

    public Task<List<string>> GetUserPermissions(Guid? UserId);
}
