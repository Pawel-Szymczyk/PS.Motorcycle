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

        Task<Dictionary<string, string>> GetMakeDictionaryAsync();
        Task<Dictionary<string, string>> GetModelDictionaryAsync(string make);
        Task<Dictionary<int, int>> GetProductionYearDictionaryAsync();
        Task<Dictionary<int, int>> GetEngineCapacityDictionaryAsync();

        Task<AzureCognitiveSearchData> ExecuteByBodyTypeFilterAsync(AzureCognitiveSearchData model);
        Task<AzureCognitiveSearchData> GetFilteredDataAsync(AzureCognitiveSearchData model);

        Task<AzureCognitiveSearchData> ExecutePageAsync(AzureCognitiveSearchData model);
        Task<AzureCognitiveSearchData> ExecuteFacetAsync(AzureCognitiveSearchData model);

    }
}