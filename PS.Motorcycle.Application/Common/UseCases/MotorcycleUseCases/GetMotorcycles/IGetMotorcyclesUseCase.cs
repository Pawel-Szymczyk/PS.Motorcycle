using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles
{
    public interface IGetMotorcyclesUseCase
    {
        Task<IEnumerable<IMotorcycleDTO>> Execute();
    }
}