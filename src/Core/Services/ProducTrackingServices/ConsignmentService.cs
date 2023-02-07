using Microsoft.EntityFrameworkCore;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Core.Services.ProducTrackingServices;
public class ConsignmentService : IConsignmentService
{
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _currentUserService;

    public ConsignmentService(IUnitOfWork uow, ICurrentUserService currentUserService)
    {
        _uow = uow;
        _currentUserService = currentUserService;

    }
    public async Task<List<Consignment>> GetAsync()
    {

        try
        {
            var repo = await _uow.Repository<Consignment>()
            .GetList<Consignment>(
                include: x => x.Include(y => y.Container)
                .Include(y => y.ConsignmentItems).ThenInclude(x => x.Item)

                ,
                selector: x => x
            );
            return repo;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    public async Task<Consignment> SaveAsync(Consignment consignment)
    {
        try
        {
            var saveconsignment = await _uow.Repository<Consignment>().InsertAsync(consignment);
            await _uow.SaveChangesAsync();
            return saveconsignment;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public async Task<Consignment> UpdateAsync(Guid id, Consignment consignment)
    {
        var repo = _uow.Repository<Consignment>();
        repo.Update(consignment);
        await _uow.SaveChangesAsync();
        return consignment;
    }

    public async Task<Consignment> DeleteAsync(Guid id)
    {
        var repo = _uow.Repository<Consignment>();
        var consignment = repo.GetById(id);
        _uow.Repository<Consignment>()
            .Delete(consignment);
        await _uow.SaveChangesAsync();
        return consignment;
    }

    public async Task<Consignment> GetByIdAsync(Guid id)
    {
        try
        {
            var repo = await _uow.Repository<Consignment>()
            .GetFirstOrDefault<Consignment>(
                predicate: x => x.Id == id,
                include: x => x.Include(y => y.Container).ThenInclude(y => y.Source)
                .Include(y => y.StartingStation)
                .Include(y => y.Destination)
                .Include(y => y.ConsignmentItems).ThenInclude(y=>y.Item)
                .Include(y => y.Package)

                ,
                selector: x => x
            );
            return repo;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public async Task<List<Consignment>> GetRecentConsignmentAsync()
    {

        var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.ConsignmentDate >= DateTime.Today.AddDays(-10)).ToList();
        _uow.SaveChanges();
        return consignmentrepo;

    }


    public async Task<List<Consignment>> GetReceivedConsignmentAsync()
    {

        var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.CurrentLocationId == _currentUserService.UserInfo.CheckpointId).ToList();
        _uow.SaveChanges();
        return consignmentrepo;

    }

    public async Task<List<Consignment>> GetSentConsignmentAsync()
    {

        var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.Container.SourceId == _currentUserService.UserInfo.CheckpointId).ToList();
        _uow.SaveChanges();
        return consignmentrepo;

    }
    public async Task<List<ContainerConsignment>> GetContainerConsignmentAsync(Guid id)
    {

        try
        {
            var consignmentrepo = await _uow.Repository<ContainerConsignment>()
            .GetList<ContainerConsignment>(x => x.ConsignmentId == id,
                 y => y.OrderBy(z => z.EntryDate),
                include: x => x.Include(y => y.Container)
                .ThenInclude(x => x.Source)
                 .Include(y => y.Container)
                .ThenInclude(x => x.Destination)
                ,
                selector: x => x
            );
            return consignmentrepo;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public async Task<List<Consignment>> GetIncomingConsignmentAsync()
    {

        var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.Container.DestinationId == _currentUserService.UserInfo.CheckpointId).ToList();
        _uow.SaveChanges();
        return consignmentrepo;

    }

    public async Task<List<Consignment>> GetOutgoingConsignmentAsync()
    {

        var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.Container.SourceId == _currentUserService.UserInfo.CheckpointId).ToList();
        _uow.SaveChanges();
        return consignmentrepo;

    }

    public async Task<List<Consignment>> GetPaidConsignmentAsync()
    {

        var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.PaymentStatus == 0).ToList();
        _uow.SaveChanges();
        return consignmentrepo;

    }

    public async Task<List<Consignment>> GetConsignmentAtCheckpointsAsync()
    {

        var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.CurrentLocationId != null).ToList();
        _uow.SaveChanges();
        return consignmentrepo;

    }

    public async Task<List<Consignment>> GetFilterConsignmentsAsync(int time)
    {
        var consignmentrepo = _uow.Repository<Consignment>();
        Dictionary<int, DateTime> periods
            = new Dictionary<int, DateTime>()
        {
            {1, DateTime.Today },
            {2, DateTime.Today.AddDays(-7)},
            {3, DateTime.Today.AddMonths(-1)},
            {4, DateTime.Today.AddMonths(-3)},
            {5, DateTime.Today.AddMonths(-6)},
            {6, DateTime.Today.AddYears(-1)},
            {7, new DateTime(0)},
        };

        return consignmentrepo.GetAll(x => x.ConsignmentDate.Date >= periods[time]).ToList();
    }


    public async Task<List<Consignment>> GetSuggestConsignmentsAsync(string param)
    {

        var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.ConsignmentNo.StartsWith(param)).ToList();
        _uow.SaveChanges();
        return consignmentrepo;

    }
    public async Task<List<Consignment>> GetCheckpointConsignmentsAsync()
    {

        //var consignmentrepo = _uow.Repository<Consignment>().GetAll(x => x.ContainerId == null && x.CurrentLocationId == _currentUserService.UserInfo.CheckpointId, null, y => y.ConsignmentItems).ToList();
        //_uow.SaveChanges();
        //return consignmentrepo;

        try
        {
            var repo = await _uow.Repository<Consignment>()
            .GetList<Consignment>(
                predicate: x => x.ContainerId == null && x.CurrentLocationId == _currentUserService.UserInfo.CheckpointId,
                null,
                 include: x => x.Include(y => y.ConsignmentItems).ThenInclude(y => y.Item)
               ,
                selector: x => x
            );
            return repo;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}
