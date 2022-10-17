using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.Interfaces
{
    public interface IMotorcycleRepository
    {
        Task<IEnumerable<PS.Motorcycle.Domain.Models.Motorcycle>> GetAsync();
        Task<IMotorcycle> GetByIdAsync(Guid id);
        Task<IMotorcycle> AddAsync(IMotorcycle motorcycle);
        Task<IMotorcycle> UpdateAsync(IMotorcycle motorcycle);
        Task<IMotorcycle> RemoveAsync(Guid id);
    }
}
