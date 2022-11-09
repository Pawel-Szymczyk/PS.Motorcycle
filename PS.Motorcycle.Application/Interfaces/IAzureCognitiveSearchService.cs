
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;

namespace PS.Motorcycle.Application.Interfaces
{
    public interface IAzureCognitiveSearchService
    {
        Task<IEnumerable<IMotorcycleDTO>> Query(Search search);
    }
}