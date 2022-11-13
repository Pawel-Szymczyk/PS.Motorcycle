using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles
{
    public class GetMotorcyclesUseCase : IGetMotorcyclesUseCase
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        public GetMotorcyclesUseCase(IMotorcycleRepository motorcycleRepository)
        {
            this._motorcycleRepository = motorcycleRepository;
        }

        public async Task<PagedItems<IMotorcycleDTO>> Execute(int currentPage)
        {
            var motorcycleslist = await this._motorcycleRepository.GetAsync(currentPage);

            return motorcycleslist;
        }

    }
}
