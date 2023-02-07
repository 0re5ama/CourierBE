using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Core.Services.ProducTrackingServices;
public class HeaderContactDetailService:IHeaderContactDetailService
{
    private readonly IUnitOfWork _uow;
    public HeaderContactDetailService(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<HeaderContactDetail>> GetAsync()
    {
        var headerContactDetailrepo = _uow.Repository<HeaderContactDetail>().GetAll().ToList();
        _uow.SaveChanges();
        return headerContactDetailrepo;

    }
    public async Task<HeaderContactDetail> SaveAsync(HeaderContactDetail headerContactDetail)
    {
        try
        {
            var saveheaderContactDetail = await _uow.Repository<HeaderContactDetail>().InsertAsync(headerContactDetail);
            await _uow.SaveChangesAsync();
            return saveheaderContactDetail;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public async Task<HeaderContactDetail> UpdateAsync(Guid id, HeaderContactDetail headerContactDetail)
    {
        var repo = _uow.Repository<HeaderContactDetail>();
        repo.Update(headerContactDetail);
        await _uow.SaveChangesAsync();
        return headerContactDetail;
    }

    public async Task<HeaderContactDetail> DeleteAsync(Guid id)
    {
        var repo = _uow.Repository<HeaderContactDetail>();
        var headerContactDetail = repo.GetById(id);
        _uow.Repository<HeaderContactDetail>()
            .Delete(headerContactDetail);
        await _uow.SaveChangesAsync();
        return headerContactDetail;
    }

    public async Task<HeaderContactDetail> GetByIdAsync(Guid id)
    {
        var repo = _uow.Repository<HeaderContactDetail>()
            .GetAll(x => x.Id == id).SingleOrDefault();
        return repo;
    }
}
