using Microsoft.EntityFrameworkCore;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Core.Services.ProducTrackingServices;
public class ContainerService : IContainerService
{
    private readonly IUnitOfWork _uow;
    private readonly ICurrentUserService _currentUserService;
    public ContainerService(IUnitOfWork uow, ICurrentUserService currentUserService)
    {
        _uow = uow;
        _currentUserService = currentUserService;
    }
    public async Task<List<Container>> GetAsync()
    {
        var containerrepo = _uow.Repository<Container>().GetAll(null, null, x => x.Source, x => x.Destination, x => x.ContainerConsignments).ToList();
        return containerrepo;

    }
    public async Task<Container> SaveAsync(Container container)
    {

        try
        {
            var consignments = container.ContainerConsignments.Select(x => x.ConsignmentId).ToArray();
            var savecontainer = await _uow.Repository<Container>().InsertAsync(container);

            var dbConsignments = _uow.Repository<Consignment>()
                .GetAll(x => consignments.Contains(x.Id)).ToList();

            dbConsignments.ForEach(x =>
            {
                x.ContainerId = container.Id;
                x.CurrentLocationId = null;
            });
            await _uow.SaveChangesAsync();

            return savecontainer;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public async Task<Container> UpdateAsync(Guid id, Container container)
    {
        container.ContainerConsignments.ForEach(x =>
        {
            x.RecivedDate = DateTime.Now;
        });
        var consignments = container.ContainerConsignments.Select(x => x.ConsignmentId).ToArray();

        var repo = _uow.Repository<Container>();
        repo.Update(container);

        var dbConsignments = _uow.Repository<Consignment>()
            .GetAll(x => consignments.Contains(x.Id)).ToList();

        dbConsignments.ForEach(x =>
        {
            x.ContainerId = null;
            x.CurrentLocationId = _currentUserService.UserInfo.CheckpointId;
        });


        await _uow.SaveChangesAsync();
        return container;
    }

    public async Task<Container> DeleteAsync(Guid id)
    {
        var repo = _uow.Repository<Container>();
        var container = repo.GetById(id);
        _uow.Repository<Container>()
            .Delete(container);
        await _uow.SaveChangesAsync();
        return container;
    }

    public async Task<Container> GetByIdAsync(Guid id)
    {
        try
        {
            var repo = await _uow.Repository<Container>()
            .GetFirstOrDefault<Container>(
                predicate: x => x.Id == id,
                include: x => x.Include(y => y.ContainerConsignments)
                    .ThenInclude(y => y.Consignment)
                        .ThenInclude(y => y.ConsignmentItems)
                            .ThenInclude(y => y.Item),
                selector: x => x
            );
            return repo;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<Container> SaveTransferAsync(Container container)
    {
        try
        {
            Guid oldContainerId = container.Id;
             container.Id = new Guid();
            var containerConsigments = container.ContainerConsignments;
            containerConsigments.ForEach (x =>
            {
                x.Id = new Guid();
            });
            var consignments = container.ContainerConsignments.Select(x => x.ConsignmentId).ToArray();
            var savecontainer = await _uow.Repository<Container>().InsertAsync(container);
            var dbConsignments = _uow.Repository<Consignment>()
                .GetAll(x => consignments.Contains(x.Id)).ToList();
            dbConsignments.ForEach(x =>
            {
                x.ContainerId = container.Id;
                x.CurrentLocationId = null;
            });
            await _uow.SaveChangesAsync();
 
            var oldContainer = _uow.Repository<Container>().GetAll(x => x.Id == oldContainerId).SingleOrDefault();
            oldContainer.TransferContainerId = container.Id;
            await _uow.SaveChangesAsync();

            return savecontainer;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public async Task<List<Container>> GetcheckpointContainerAsync()
    {
        var containerrepo = _uow.Repository<Container>().GetAll(x=>x.DestinationId == _currentUserService.UserInfo.CheckpointId &&
                x.IsReceived != true &&
                x.TransferContainerId == null, null, x => x.Source, x => x.Destination, x => x.ContainerConsignments).ToList();
        return containerrepo;

    }
}
