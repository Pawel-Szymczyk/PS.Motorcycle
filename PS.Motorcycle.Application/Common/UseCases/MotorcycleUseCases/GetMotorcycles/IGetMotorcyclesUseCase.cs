using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles
{
    public interface IGetMotorcyclesUseCase
    {
        Task<IEnumerable<IMotorcycle>> Execute();
    }
}