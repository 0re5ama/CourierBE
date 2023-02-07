using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Core.Interfaces.ProductTrackingInterFaces;
public interface ICheckpointService
{
    public Task<List<Checkpoint>> GetAsync();
    public Task<Checkpoint> SaveAsync(Checkpoint checkpoint);
    public Task<Checkpoint> GetByIdAsync(Guid id);
    public Task<Checkpoint> UpdateAsync(Guid id, Checkpoint checkpoint);
    public Task<Checkpoint> DeleteAsync(Guid id);
    public Task<List<User>> GetCheckpointLessAsync();


}
