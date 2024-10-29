using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using Infrastructure.Persistence.EFCore.Interface;

namespace Infrastructure.Persistence.EFCore.Context;

public class APIDbEFContext : DbContext, IAPIDbEFContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), x => x.Name.EndsWith("Configuration"));

        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entry = ChangeTracker.Entries<EntityBase>().FirstOrDefault(x => x.State == EntityState.Modified);

        if (entry is { Entity.Deleted: true })
        {
            entry.Entity.DeletedDate = DateTime.UtcNow;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public override EntityEntry Remove(object entity)
    {
        var entry = Entry(entity);

        entry.State = EntityState.Modified;

        return entry;
    }
}