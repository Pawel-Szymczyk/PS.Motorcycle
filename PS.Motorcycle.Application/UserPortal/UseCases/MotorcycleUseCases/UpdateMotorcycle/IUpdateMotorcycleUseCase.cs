using PS.Motorcycle.Domain.Interfaces;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.UpdateMotorcycleUseCase
{
    internal interface IUpdateMotorcycleUseCase
    {
        Task<IMotorcycle> Execute(IMotorcycle motorcycle);
    }
}