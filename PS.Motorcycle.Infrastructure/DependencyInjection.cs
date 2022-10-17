using Microsoft.Extensions.DependencyInjection;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Infrastructure.CosmosDB.Interfaces;
using PS.Motorcycle.Infrastructure.CosmosDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Infrastructure.CosmosDB
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCosmosRepository(this IServiceCollection services)
        {
            services.AddSingleton<IMotorcycleCosmosContext, MotorcycleCosmosContext>();
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();

            return services;
        }
    }
}
