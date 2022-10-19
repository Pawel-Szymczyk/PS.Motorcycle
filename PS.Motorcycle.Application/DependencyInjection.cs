using Microsoft.Extensions.DependencyInjection;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.AddMotorcycle;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.RemoveMotorcycle;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.UpdateMotorcycleUseCase;

namespace PS.Motorcycle.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IGetMotorcycleUseCase, GetMotorcycleUseCase>();
            services.AddTransient<IGetMotorcyclesUseCase, GetMotorcyclesUseCase>();
            services.AddTransient<IAddMotorcycleUseCase, AddMotorcycleUseCase>();
            services.AddTransient<IUpdateMotorcycleUseCase, UpdateMotorcycleUseCase>();
            services.AddTransient<IRemoveMotorcycleUseCase, RemoveMotorcycleUseCase>();

            return services;
        }
    }
}
