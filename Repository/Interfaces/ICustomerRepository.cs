using Domain.Entities;
using System.Linq.Expressions;

namespace Repository.Interfaces;

public interface ICustomerRepository : IQueryRepository<Customer>, ICommandRepository<Customer>
{
    Task<List<Customer>> GetList(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default);
}