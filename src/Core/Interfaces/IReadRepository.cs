using Ardalis.Specification;

namespace ProductTracking.Core.Interfaces;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
