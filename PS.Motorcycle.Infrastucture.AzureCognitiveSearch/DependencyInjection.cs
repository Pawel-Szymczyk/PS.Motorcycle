using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Interfaces;
using PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Infrastucture.AzureCognitiveSearch
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAzureCognitiveAzureService(this IServiceCollection services)
        {
            //services.AddSingleton<IMotorcycleCosmosContext, MotorcycleCosmosContext>();
            //services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();

            

            services.AddSingleton<IAzureCognitiveSearchContext, AzureCognitiveSearchContext>();
            services.AddScoped<IAzureCognitiveSearchService, AzureCognitiveSearchService>();

            return services;
        }
    }
}
