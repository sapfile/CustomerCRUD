using Domain.Entities;

namespace Infrastructure.Persistence.JSON.Interface;

public interface IJsonContext
{
    Task<List<T>?> GetDataList<T>(CancellationToken cancellationToken) where T : EntityBase;
    Task Save<T>(List<T> Entity, CancellationToken cancellationToken) where T : EntityBase;
}