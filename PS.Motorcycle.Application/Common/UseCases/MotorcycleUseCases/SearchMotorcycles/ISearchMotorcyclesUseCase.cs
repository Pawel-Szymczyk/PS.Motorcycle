using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.DTO;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles
{
    public interface ISearchMotorcyclesUseCase
    {
        //Task<IEnumerable<IMotorcycleDTO>> Execute(Search searchQuery);


        Task<AzureCognitiveSearchData> Execute(AzureCognitiveSearchData model);

        Task<AzureCognitiveSearchData> ExecuteByBodyTypeFilterAsync(AzureCognitiveSearchData model);

        Task<AzureCognitiveSearchData> ExecutePageAsync(AzureCognitiveSearchData model);
        Task<AzureCognitiveSearchData> ExecuteFacetAsync(AzureCognitiveSearchData model);

    }
}