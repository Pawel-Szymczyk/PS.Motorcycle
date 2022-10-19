using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.UpdateMotorcycleUseCase
{
    internal class UpdateMotorcycleUseCase : IUpdateMotorcycleUseCase
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        public UpdateMotorcycleUseCase(IMotorcycleRepository motorcycleRepository)
        {
            this._motorcycleRepository = motorcycleRepository;
        }

        public async Task<IMotorcycle> Execute(IMotorcycle motorcycle)
        {

            if (!motorcycle.Equals(null))
                return null;


            Domain.Models.Motorcycle moto = motorcycle as Domain.Models.Motorcycle;


            var result = await this._motorcycleRepository.UpdateAsync(moto);

            return result;
        }
    }
}
