using Domain.Entities;

namespace Repository.Interfaces;

public interface ICommandRepository<T> where T : EntityBase
{
    Task Insert(T entity, CancellationToken cancellationToken = default);

    Task<T> Update(T entity, CancellationToken cancellationToken = default);

    Task Delete(int id, CancellationToken cancellationToken = default);
}