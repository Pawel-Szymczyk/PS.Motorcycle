using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.Interfaces
{
    public interface IMotorcycleRepository
    {
        //Task<IEnumerable<MotorcycleDTO>> GetAsync();
        Task<MotorcycleResponse<IMotorcycleDTO>> GetAsync(MotorcycleRequest request);
        Task<MotorcycleResponse<IMotorcycleDTO>> GetAsync(int currentPage);
        Task<Domain.Models.Motorcycle> GetByIdAsync(Guid id);
        Task<Domain.Models.Motorcycle> AddAsync(Domain.Models.Motorcycle motorcycle);
        Task<Domain.Models.Motorcycle> UpdateAsync(Domain.Models.Motorcycle motorcycle);
        Task<Domain.Models.Motorcycle> RemoveAsync(Guid id);
    }
}
