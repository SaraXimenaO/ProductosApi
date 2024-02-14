using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using Products.Infrastructure.Adapters;
using Products.Infrastructure.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Extensions;

public static class LoadServices
{
   public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        var repositories = AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly =>
            {
                return (assembly.FullName is not null) || assembly.FullName.Contains("Infrastructure", StringComparison.InvariantCulture);
            })
            .SelectMany(s => s.GetTypes())
            .Where(x => x.CustomAttributes.Any(a => a.AttributeType == typeof(RepositoryAttribute)));

        foreach (var repository in repositories)
        {
            services.AddTransient(repository.GetInterfaces().Single(), repository);
        }

        return services;
    }

}
