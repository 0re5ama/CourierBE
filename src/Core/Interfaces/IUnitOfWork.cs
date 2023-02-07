namespace ProductTracking.Core.Interfaces;
public interface IUnitOfWork : IDisposable
{
    public void BeginTransaction();
    public int Commit();
    public Task<int> CommitAsync();
    public void Dispose();
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    public void Rollback();
    public int SaveChanges();
    public Task<int> SaveChangesAsync();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
