using Microsoft.Azure.Cosmos;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Infrastructure.CosmosDB.Interfaces;

namespace PS.Motorcycle.Infrastructure.CosmosDB.Repositories
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly IMotorcycleCosmosContext _cosmosContext;

        public MotorcycleRepository(IMotorcycleCosmosContext cosmosContext)
        {
            this._cosmosContext = cosmosContext;
        }

        public async Task<Domain.Models.Motorcycle> AddAsync(Domain.Models.Motorcycle motorcycle)
        {
            var partitionKey = new PartitionKey(motorcycle.Id.ToString());
            var result = await _cosmosContext.MotorcycleContainer.CreateItemAsync(motorcycle, partitionKey);
            return result.Resource;
        }

        public async Task<IEnumerable<Domain.Models.Motorcycle>> GetAsync()
        {
            var queryDefination = new QueryDefinition("SELECT * FROM Motorcycle");
            var query = _cosmosContext.MotorcycleContainer.GetItemQueryIterator<Domain.Models.Motorcycle>(queryDefination);

            var result = new List<PS.Motorcycle.Domain.Models.Motorcycle>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response.ToList());
            }

            return result;
        }

        public async Task<Domain.Models.Motorcycle> GetByIdAsync(Guid id)
        {
            var partitionKey = new PartitionKey(id.ToString());
            var results = await this._cosmosContext.MotorcycleContainer.ReadItemAsync<Domain.Models.Motorcycle>(id.ToString(), partitionKey); 
            return results.Resource;
        }

        public async Task<Domain.Models.Motorcycle> RemoveAsync(Guid id)
        {
            var partitionKey = new PartitionKey(id.ToString());
            var result = await this._cosmosContext.MotorcycleContainer.DeleteItemAsync<Domain.Models.Motorcycle>(id.ToString(), partitionKey);  

            return result.Resource;
        }

        public async Task<Domain.Models.Motorcycle> UpdateAsync(Domain.Models.Motorcycle motorcycle)
        {
            var partitionKey = new PartitionKey(motorcycle.Id.ToString());
            var result = await this._cosmosContext.MotorcycleContainer.UpsertItemAsync(motorcycle, partitionKey);
            return result.Resource;

        }
    }
}
