using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Core.Services.ProducTrackingServices;
public class ItemGroupService : IItemGroupService
{
    private readonly IUnitOfWork _uow;
    public ItemGroupService(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<ItemGroup>> GetAsync()
    {
        var itemrepo = _uow.Repository<ItemGroup>().GetAll().ToList();
        _uow.SaveChanges();
        return itemrepo;

    }
    public async Task<ItemGroup> SaveAsync(ItemGroup item)
    {
        try
        {
            var saveitem = await _uow.Repository<ItemGroup>().InsertAsync(item);
            await _uow.SaveChangesAsync();
            return saveitem;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public async Task<ItemGroup> UpdateAsync(Guid id, ItemGroup item)
    {
        var repo = _uow.Repository<ItemGroup>();
        repo.Update(item);
        await _uow.SaveChangesAsync();
        return item;
    }

    public async Task<ItemGroup> DeleteAsync(Guid id)
    {
        var repo = _uow.Repository<ItemGroup>();
        var item = repo.GetById(id);
        _uow.Repository<ItemGroup>()
            .Delete(item);
        await _uow.SaveChangesAsync();
        return item;
    }

    public async Task<ItemGroup> GetByIdAsync(Guid id)
    {
        var repo = _uow.Repository<ItemGroup>()
            .GetAll(x => x.Id == id,null,y=>y.Items).SingleOrDefault();
        return repo;
    }
}
