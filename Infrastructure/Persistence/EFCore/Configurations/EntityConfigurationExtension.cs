using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EFCore.Configurations;

public static class EntityConfigurationExtension
{
    public static void ApplyBaseConfigurations<T>(this EntityTypeBuilder<T> builder) where T : EntityBase
    {
        builder.HasQueryFilter(x => x.Deleted == false);
    }
}