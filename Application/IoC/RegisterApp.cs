using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace Application.IoC;

public static class RegisterApp
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(GeneralException<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(Validation<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(Performance<,>));
        });

        services.AddTransient<Stopwatch>();


        return services;
    }
}