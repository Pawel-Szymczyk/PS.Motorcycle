using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles
{
    public interface IGetMotorcycleUseCase
    {
        Task<IMotorcycle> Execute(Guid id);
    }
}