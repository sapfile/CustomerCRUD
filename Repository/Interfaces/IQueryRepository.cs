using Domain.Entities;

namespace Repository.Interfaces;

public interface IQueryRepository<T> where T : EntityBase
{
    Task<T?> GetById(int id, CancellationToken cancellationToken = default);

    Task<List<T>> GetList(CancellationToken cancellationToken = default);
}