using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.AddMotorcycle
{
    public interface IAddMotorcycleUseCase
    {
        Task Execute(IMotorcycle motorcycle);
    }
}