using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.RemoveMotorcycle
{
    public class RemoveMotorcycleUseCase : IRemoveMotorcycleUseCase
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        public RemoveMotorcycleUseCase(IMotorcycleRepository motorcycleRepository)
        {
            this._motorcycleRepository = motorcycleRepository;
        }

        public async Task<IMotorcycle> Execute(Guid id)
        {
            // TODO: check what response I get if id exists or does not exist and return some form of message instead of object

            var result = await this._motorcycleRepository.RemoveAsync(id);

            return result;
        }
    }
}
