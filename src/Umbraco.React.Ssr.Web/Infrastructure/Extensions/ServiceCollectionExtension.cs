using System.Reflection;

namespace Umbraco.React.Ssr.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services, IEnumerable<Assembly> assemblies, Type[] ignoredTypes)
        {
            var interfaces = assemblies
                .SelectMany(x => x.GetTypes().Where(t => t.Namespace != null))
                .Where(t => t.IsInterface && !ignoredTypes.Any(x => Equals(x, t)))
                .ToArray();

            if(interfaces == null)
            {
                return services;
            }

            foreach (var i in interfaces)
            {
                var implementations = assemblies
                    .SelectMany(x => x.GetTypesAssignableFrom(i))
                    .Where(t => !(t.IsInterface || t.Name.StartsWith("Mock") || t.Name.StartsWith("Null") || t.Name.StartsWith("Stub") || t.IsAbstract));

                if(implementations == null)
                {
                    continue;
                }

                foreach (var implementation in implementations)
                {
                    services.AddScoped(i, implementation);
                }
            }

            return services;
        }

        public static IServiceCollection AddAllOfType(this IServiceCollection services, Type type, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var list = new List<Type>();

            foreach (var assembly in assemblies)
            {
                list.AddRange(assembly.GetTypesAssignableFrom(type));
            }

            list.ForEach((t) =>
            {
                switch (lifetime)
                {
                    case ServiceLifetime.Scoped:
                        services.AddScoped(t);
                        break;

                    case ServiceLifetime.Transient:
                        services.AddTransient(t);
                        break;

                    case ServiceLifetime.Singleton:
                        services.AddSingleton(t);
                        break;
                }
            });
            return services;
        }

        public static IServiceCollection AddAllOfInterfaceType(this IServiceCollection services, Type type, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var list = new List<Type>();

            foreach (var assembly in assemblies)
            {
                list.AddRange(assembly.GetTypesAssignableFrom(type));
            }

            list.ForEach((t) =>
            {
                switch (lifetime)
                {
                    case ServiceLifetime.Scoped:
                        services.AddScoped(type, t);
                        break;

                    case ServiceLifetime.Transient:
                        services.AddTransient(type, t);
                        break;

                    case ServiceLifetime.Singleton:
                        services.AddSingleton(type, t);
                        break;
                }
            });
            return services;
        }
    }
}
