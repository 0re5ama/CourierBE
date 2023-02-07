using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Core.Interfaces.ProductTrackingInterFaces;
public interface IHeaderContactDetailService
{
    public Task<List<HeaderContactDetail>> GetAsync();
    public Task<HeaderContactDetail> SaveAsync(HeaderContactDetail headerConatctDetail);
    public Task<HeaderContactDetail> GetByIdAsync(Guid id);
    public Task<HeaderContactDetail> UpdateAsync(Guid id, HeaderContactDetail headerConatctDetail);
    public Task<HeaderContactDetail> DeleteAsync(Guid id);
}
