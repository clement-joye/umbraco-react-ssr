using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.React.Ssr.Application.Behaviours;

namespace Umbraco.React.Ssr.Application;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(new[] { Assembly.GetEntryAssembly(), Assembly.GetExecutingAssembly() });
        services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());
        services.AddMediatR(Assembly.GetCallingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        return services;
    }
}
