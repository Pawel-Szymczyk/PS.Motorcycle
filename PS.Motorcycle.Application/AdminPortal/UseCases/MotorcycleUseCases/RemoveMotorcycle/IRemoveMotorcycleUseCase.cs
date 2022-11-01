using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.AdminPortal.UseCases.MotorcycleUseCases.RemoveMotorcycle
{
    public interface IRemoveMotorcycleUseCase
    {
        Task<IMotorcycle> Execute(Guid id);
    }
}