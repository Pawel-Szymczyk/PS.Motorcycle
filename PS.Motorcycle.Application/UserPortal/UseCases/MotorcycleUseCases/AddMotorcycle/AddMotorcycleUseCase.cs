using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.AddMotorcycle
{
    public class AddMotorcycleUseCase : IAddMotorcycleUseCase
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        public AddMotorcycleUseCase(IMotorcycleRepository motorcycleRepository)
        {
            this._motorcycleRepository = motorcycleRepository;
        }

        public async Task Execute(IMotorcycle motorcycle)
        {
            if (!motorcycle.Equals(null))
                return;

            Domain.Models.Motorcycle? moto = motorcycle as Domain.Models.Motorcycle;
            moto.Id = Guid.NewGuid();

            await this._motorcycleRepository.AddAsync(moto);
        }
    }
}
