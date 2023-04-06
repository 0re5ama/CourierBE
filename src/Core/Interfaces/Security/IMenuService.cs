using ProductTracking.Core.DTO;
using ProductTracking.Core.Entities.AuthAggregate;

namespace ProductTracking.Core.Interfaces.Security;
public interface IMenuService
{
    public Task<List<MenuDTO>> GetAsync();
}
