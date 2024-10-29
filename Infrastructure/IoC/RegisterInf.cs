using Infrastructure.Persistence.EFCore.Context;
using Infrastructure.Persistence.EFCore.Interface;
using Infrastructure.Persistence.JSON.Context;
using Infrastructure.Persistence.JSON.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class RegisterInf
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IJsonContext, JsonContext>();
        services.AddScoped<IAPIDbEFContext, APIDbEFContext>();

        return services;
    }
}