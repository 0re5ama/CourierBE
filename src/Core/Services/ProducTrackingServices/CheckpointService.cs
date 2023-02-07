using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.AuthAggregate;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces;
using ProductTracking.Core.Interfaces.ProductTrackingInterFaces;

namespace ProductTracking.Core.Services.ProducTrackingServices;
public class CheckpointService:ICheckpointService
{
    private readonly IUnitOfWork _uow;
    public CheckpointService(IUnitOfWork uow)
    {
        _uow = uow;
    }
    public async Task<List<Checkpoint>> GetAsync()
    {
        var checkpointrepo = _uow.Repository<Checkpoint>().GetAll(null,null,x=>x.Consignments).ToList();
        return checkpointrepo;

    }
    public async Task<Checkpoint> SaveAsync(Checkpoint checkpoint)
    {
        try
        {
            var users = checkpoint.Users.Select(x => x.Id).ToArray();
            checkpoint.Users = null;
            var savecheckpoint = await _uow.Repository<Checkpoint>().InsertAsync(checkpoint);

            var dbUsers = _uow.Repository<User>()
                .GetAll(x => users.Contains(x.Id)).ToList();

            dbUsers.ForEach(x =>
            {
                x.CheckpointId = checkpoint.Id;
            });

            await _uow.SaveChangesAsync();
            return savecheckpoint;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public async Task<Checkpoint> UpdateAsync(Guid id, Checkpoint checkpoint)
    {
        var users = checkpoint.Users.Select(x => x.Id).ToArray();
        checkpoint.Users = null;
        var repo = _uow.Repository<Checkpoint>();
        repo.Update(checkpoint);
        var dbUsers = _uow.Repository<User>()
            .GetAll(x => users.Contains(x.Id)).ToList();

        dbUsers.ForEach(x =>
        {
            x.CheckpointId = checkpoint.Id;
        });

        await _uow.SaveChangesAsync();
        return checkpoint;
    }

    public async Task<Checkpoint> DeleteAsync(Guid id)
    {
        var repo = _uow.Repository<Checkpoint>();
        var checkpoint = repo.GetById(id);
        _uow.Repository<Checkpoint>()
            .Delete(checkpoint);
        await _uow.SaveChangesAsync();
        return checkpoint;
    }

    public async Task<Checkpoint> GetByIdAsync(Guid id)
    {
        var repo = _uow.Repository<Checkpoint>()
            .GetAll(x => x.Id == id,null,y=>y.Users).SingleOrDefault();
        return repo;
    }

    public async Task<List<User>> GetCheckpointLessAsync()
    {
        var checkpointlessrepo = _uow.Repository<User>().GetAll(x=>x.CheckpointId == null).ToList();
        return checkpointlessrepo;

    }
} 
