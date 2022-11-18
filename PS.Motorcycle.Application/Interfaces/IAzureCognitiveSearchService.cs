
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.DTO;

namespace PS.Motorcycle.Application.Interfaces
{
    public interface IAzureCognitiveSearchService
    {
        Task<IEnumerable<IMotorcycleDTO>> Query(Search search);


        Task<AzureCognitiveSearchData> RunQueryAsync(AzureCognitiveSearchData model, int page, int leftMostPage, string bodyTypeFilter);
    }
}