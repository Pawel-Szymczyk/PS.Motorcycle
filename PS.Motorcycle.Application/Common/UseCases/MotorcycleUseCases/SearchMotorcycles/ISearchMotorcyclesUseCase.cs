using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles
{
    public interface ISearchMotorcyclesUseCase
    {
        Task<IEnumerable<IMotorcycleDTO>> Execute(Search searchQuery);
    }
}