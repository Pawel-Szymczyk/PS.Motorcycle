using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles
{
    public interface ISearchMotorcyclesUseCase
    {
        Task<IEnumerable<IMotorcycle>> Execute(Search searchQuery);
    }
}