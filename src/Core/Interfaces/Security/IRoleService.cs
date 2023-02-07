using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Core.Interfaces.Security;
public interface IRoleService
{
    public Task<List<Role>> GetAsync();
    public Task<Role> GetAsync(Guid id);
    public Task<Role> SaveAsync(Role role);
    public Task<Role> UpdateAsync(Guid id, Role role);
    public Task<Role> DeleteAsync(Guid id);
}
