﻿using System.Collections;
using ProductTracking.Core.Interfaces;

namespace ProductTracking.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private IDbContext _context;
    private bool _disposed;
    private Hashtable _repositories;
    public UnitOfWork(IDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _context.BeginTransaction();
    }

    public int Commit()
    {
        return _context.Commit();
    }

    public Task<int> CommitAsync()
    {
        return _context.CommitAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();

            if (_repositories != null && _repositories.Values != null && _repositories.Values.OfType<IDisposable>().Any())
            {
                foreach (IDisposable repository in _repositories.Values)
                {
                    repository.Dispose();
                }
            }
        }
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        var type = typeof(TEntity).Name;
        if (_repositories.ContainsKey(type))
            return (IRepository<TEntity>)_repositories[type];

        var repositoryType = typeof(GenericRepository<>);
        _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context));
        return (IRepository<TEntity>)_repositories[type];
    }

    public void Rollback()
    {
        _context.Rollback();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
