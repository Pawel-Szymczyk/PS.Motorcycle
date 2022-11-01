using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.AdminPortal.UseCases.MotorcycleUseCases.UpdateMotorcycleUseCase
{
    public interface IUpdateMotorcycleUseCase
    {
        Task<IMotorcycle> Execute(IMotorcycle motorcycle);
    }
}