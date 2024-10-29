using Domain.Entities;
using Repository.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.EFCore.Interface;

namespace Repository.Repositories.EFCore
{
    public class EFCustomerRepository(IAPIDbEFContext context) : ICustomerRepository
    {
        public async Task<Customer?> GetById(int id, CancellationToken cancellationToken = default)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return customer;
        }

        public async Task<List<Customer>> GetList(CancellationToken cancellationToken = default)
        {
            var customers = await context.Customers.ToListAsync(cancellationToken: cancellationToken);

            return customers;
        }

        public async Task Insert(Customer entity, CancellationToken cancellationToken = default)
        {
            await context.Customers.AddAsync(entity, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Customer> Update(Customer entity, CancellationToken cancellationToken = default)
        {
            var customer = await GetById(entity.Id, cancellationToken);

            if(customer == null)
                throw new InvalidOperationException();

            context.Customers.Attach(entity);

            await context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var customer = await GetById(id, cancellationToken);

            if (customer == null)
                throw new InvalidOperationException();

            context.Customers.Remove(customer);

            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Customer>> GetList(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var customers = await context.Customers.Where(predicate).ToListAsync(cancellationToken);

            return customers;
        }
    }
}
