using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Core.Interfaces.ProductTrackingInterFaces;
public interface IPackageService
{
    public Task<List<Package>> GetAsync();
    public Task<Package> SaveAsync(Package package);
    public Task<Package> GetByIdAsync(Guid id);
    public Task<Package> UpdateAsync(Guid id, Package package);
    public Task<Package> DeleteAsync(Guid id);
}
