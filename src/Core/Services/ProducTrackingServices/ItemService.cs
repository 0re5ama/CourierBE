using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Core.Services.ProducTrackingServices;
public class ItemService : IItemService
{
    private readonly IUnitOfWork _uow;
    public ItemService(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<Item>> GetAsync()
    {
        var itemrepo = _uow.Repository<Item>().GetAll(null,null,x=>x.ItemGroup).ToList();
      
        return itemrepo;

    }
    public async Task<Item> SaveAsync(Item item)
    {
        try
        {
            var saveitem = await _uow.Repository<Item>().InsertAsync(item);
            await _uow.SaveChangesAsync();
            return saveitem;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public async Task<Item> UpdateAsync(Guid id, Item item)
    {
        var repo = _uow.Repository<Item>();
        repo.Update(item);
        await _uow.SaveChangesAsync();
        return item;
    }

    public async Task<Item> DeleteAsync(Guid id)
    {
        var repo = _uow.Repository<Item>();
        var item = repo.GetById(id);
        _uow.Repository<Item>()
            .Delete(item);
        await _uow.SaveChangesAsync();
        return item;
    }

    public async Task<Item> GetByIdAsync(Guid id)
    {
        var repo = _uow.Repository<Item>()
            .GetAll(x => x.Id == id).SingleOrDefault();
        return repo;
    }
    public async Task<List<Item>> GetByItemGroupAsync(Guid id)
    {
        var repo = _uow.Repository<Item>()
            .GetAll(x => x.ItemGroupId == id).ToList();
        return repo;
    }
}

