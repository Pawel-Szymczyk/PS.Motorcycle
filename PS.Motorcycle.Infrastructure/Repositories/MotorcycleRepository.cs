using Microsoft.Azure.Cosmos;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;

using PS.Motorcycle.Infrastructure.CosmosDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Infrastructure.CosmosDB.Repositories
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly IMotorcycleCosmosContext _cosmosContext;

        public MotorcycleRepository(IMotorcycleCosmosContext cosmosContext)
        {
            this._cosmosContext = cosmosContext;
        }

        public Task<IMotorcycle> AddAsync(IMotorcycle motorcycle)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PS.Motorcycle.Domain.Models.Motorcycle>> GetAsync()
        {
            var queryDefination = new QueryDefinition("SELECT * FROM Motorcycle");
            var query = _cosmosContext.MotorcycleContainer.GetItemQueryIterator<PS.Motorcycle.Domain.Models.Motorcycle>(queryDefination);

            var result = new List<PS.Motorcycle.Domain.Models.Motorcycle>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response.ToList());
            }

            return result;
        }

        public Task<IMotorcycle> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IMotorcycle> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IMotorcycle> UpdateAsync(IMotorcycle motorcycle)
        {
            throw new NotImplementedException();
        }
    }
}
