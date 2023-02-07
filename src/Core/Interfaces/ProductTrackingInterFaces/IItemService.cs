using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.TrackingAggregate;

namespace ProductTracking.Core.Interfaces.ProductTrackingInterFaces;
public interface IItemService
{
    public Task<List<Item>> GetAsync();
    public Task<Item> SaveAsync(Item container);
    public Task<Item> GetByIdAsync(Guid id);
    public Task<List<Item>> GetByItemGroupAsync(Guid id);
    public Task<Item> UpdateAsync(Guid id, Item container);
    public Task<Item> DeleteAsync(Guid id);
}
