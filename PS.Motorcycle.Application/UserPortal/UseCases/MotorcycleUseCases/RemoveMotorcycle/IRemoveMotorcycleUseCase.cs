using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.RemoveMotorcycle
{
    public interface IRemoveMotorcycleUseCase
    {
        Task<IMotorcycle> Execute(Guid id);
    }
}