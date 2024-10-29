using Domain.Entities;
using Infrastructure.Persistence.JSON.Interface;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories.JSON;

public class JSONCustomerRepository(IJsonContext context) : ICustomerRepository
{
    public async Task<Customer?> GetById(int id, CancellationToken cancellationToken = default)
    {
        var data = await GetList(cancellationToken);

        var customer = data.FirstOrDefault(x => x.Id == id);

        return customer;
    }

    public async Task<List<Customer>> GetList(CancellationToken cancellationToken = default)
    {
        var customers = await context.GetDataList<Customer>(cancellationToken);

        return customers;
    }

    public async Task Insert(Customer entity, CancellationToken cancellationToken = default)
    {
        var customers = await GetList(cancellationToken);
        entity.Id = customers.Count == 0 ? 1 : customers.Max(x => x.Id) + 1;
        customers.Add(entity);
        
        await context.Save(customers, cancellationToken);
    }

    public async Task<Customer> Update(Customer entity, CancellationToken cancellationToken = default)
    {
        var customers = await GetList(cancellationToken);

        var studentIdx = customers.FindIndex(x => x.Id == entity.Id);

        customers[studentIdx] = entity;

        await context.Save(customers, cancellationToken);

        return entity;
    }

    public async Task Delete(int id, CancellationToken cancellationToken = default)
    {
        var customers = await GetList(cancellationToken);

        var customerToDelete = customers.FirstOrDefault(x => x.Id == id);

        customers.Remove(customerToDelete);

        await context.Save(customers, cancellationToken);
    }

    public async Task<List<Customer>> GetList(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var customers = await GetList(cancellationToken);

        var filteredCustomers = customers.Where(predicate.Compile()).ToList();

        return filteredCustomers;
    }
}