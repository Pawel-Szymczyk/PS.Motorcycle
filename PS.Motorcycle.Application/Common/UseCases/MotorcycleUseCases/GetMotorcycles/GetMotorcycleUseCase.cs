using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles
{
    public class GetMotorcycleUseCase : IGetMotorcycleUseCase
    {
        private readonly IMotorcycleRepository _motorcycleRepository;


        public GetMotorcycleUseCase(IMotorcycleRepository motorcycleRepository)
        {
            this._motorcycleRepository = motorcycleRepository;
        }

        public async Task<IMotorcycle> Execute(Guid id)
        {
            
            var motorcycle = await this._motorcycleRepository.GetByIdAsync(id);

            return motorcycle;
        }
    }
}
