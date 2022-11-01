using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles
{
    public interface ISearchMotorcyclesUseCase
    {
        Task<IMotorcycle> Execute();
    }
}