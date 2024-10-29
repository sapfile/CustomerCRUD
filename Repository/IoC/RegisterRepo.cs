using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories.EFCore;
using Repository.Repositories.JSON;

namespace Repository.IoC;

public static class RegisterRepo
{
    public static IServiceCollection RegisterRepository(this IServiceCollection services, string provider)
    {
        switch (provider)
        {
            case "JSON":
                services.AddTransient<ICustomerRepository, JSONCustomerRepository>();
                break;
            case "SQLite":
                services.AddTransient<ICustomerRepository, EFCustomerRepository>();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return services;
    }
}