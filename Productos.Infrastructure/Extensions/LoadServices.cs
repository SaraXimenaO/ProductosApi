using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Ports;
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
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IResponseTimeLogger, FileResponseTimeLogger>();

        return services;
    }

}
