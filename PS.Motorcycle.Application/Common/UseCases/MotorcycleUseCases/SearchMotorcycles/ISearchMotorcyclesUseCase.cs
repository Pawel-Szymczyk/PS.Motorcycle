using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.DTO;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles
{
    public interface ISearchMotorcyclesUseCase
    {
        Task<IEnumerable<IMotorcycleDTO>> Execute(Search searchQuery);


        Task<SearchData> Execute(SearchData model);

        Task<SearchData> ExecutePageAsync(SearchData model);
        Task<SearchData> ExecuteFacetAsync(SearchData model);

    }
}