using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models.DTO;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles
{
    public interface IGetMotorcyclesUseCase
    {
        Task<PagedItems<IMotorcycleDTO>> Execute(int currentPage);
    }
}