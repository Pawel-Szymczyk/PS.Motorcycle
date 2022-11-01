using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles
{
    public class SearchMotorcyclesUseCase : ISearchMotorcyclesUseCase
    {
        private readonly IAzureCognitiveSearchService _azureCognitiveSearchService;


        public SearchMotorcyclesUseCase(IAzureCognitiveSearchService azureCognitiveSearchService)
        {
            this._azureCognitiveSearchService = azureCognitiveSearchService;
        }

        public async Task<IMotorcycle> Execute()
        {
            await this._azureCognitiveSearchService.Query();

            return null;
        }
    }
}
