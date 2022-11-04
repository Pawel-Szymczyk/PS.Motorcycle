
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models;

namespace PS.Motorcycle.Application.Interfaces
{
    public interface IAzureCognitiveSearchService
    {
        Task<IEnumerable<IMotorcycle>> Query(Search search);
    }
}