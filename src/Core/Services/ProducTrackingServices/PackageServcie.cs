using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Core.Services.ProducTrackingServices;
public class PackageService : IPackageService
{
    private readonly IUnitOfWork _uow;
    public PackageService(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<Package>> GetAsync()
    {
        var packagerepo = _uow.Repository<Package>().GetAll().ToList();
        _uow.SaveChanges();
        return packagerepo;

    }
    public async Task<Package> SaveAsync(Package package)
    {
        try
        {
            var savepackage = await _uow.Repository<Package>().InsertAsync(package);
            await _uow.SaveChangesAsync();
            return savepackage;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public async Task<Package> UpdateAsync(Guid id, Package package)
    {
        var repo = _uow.Repository<Package>();
        repo.Update(package);
        await _uow.SaveChangesAsync();
        return package;
    }

    public async Task<Package> DeleteAsync(Guid id)
    {
        var repo = _uow.Repository<Package>();
        var package = repo.GetById(id);
        _uow.Repository<Package>()
            .Delete(package);
        await _uow.SaveChangesAsync();
        return package;
    }

    public async Task<Package> GetByIdAsync(Guid id)
    {
        var repo = _uow.Repository<Package>()
            .GetAll(x => x.Id == id).SingleOrDefault();
        return repo;
    }
}

