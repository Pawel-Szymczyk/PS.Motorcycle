using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.AdminPortal.UseCases.MotorcycleUseCases.AddMotorcycle
{
    public interface IAddMotorcycleUseCase
    {
        Task Execute(IMotorcycle motorcycle);
    }
}