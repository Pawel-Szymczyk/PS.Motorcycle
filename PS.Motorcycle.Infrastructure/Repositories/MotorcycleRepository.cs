using Microsoft.Azure.Cosmos;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.DTO;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models.DTO;
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
            try
            {
                // TODO: search response DTO required to fix this issue with JSON properites
                var partitionKey = new PartitionKey(motorcycle.Id.ToString());
                var result = await _cosmosContext.MotorcycleContainer.CreateItemAsync(motorcycle, partitionKey);
                return result.Resource;
            }
            catch (Exception ex)
            {

                return null;
            }
           
        }

        public async Task<PagedItems<IMotorcycleDTO>> GetAsync(int currentPage)
        {
            try
            {
                int pageCounter = 0;
                int totalCount = 0;

                // set additional options 
                QueryRequestOptions options = new QueryRequestOptions()
                {
                    MaxItemCount = 10
                };

                var queryDefination = new QueryDefinition("SELECT * FROM Motorcycle");
                var query = _cosmosContext.MotorcycleContainer.GetItemQueryIterator<MotorcycleDTO>(queryDefination, requestOptions: options);

                var items = new List<MotorcycleDTO>();

                // get data, count pages
                while (query.HasMoreResults)
                {
                    pageCounter++;

                    var response = await query.ReadNextAsync();
                    totalCount = totalCount + response.Count();
                    if (pageCounter == currentPage)
                    {
                        items.AddRange(response.ToList());
                    }

                }

                // create 
                var paging = new Paging(totalCount, currentPage, 10);

                return new PagedItems<IMotorcycleDTO>
                {
                    Items = items,
                    Paging = paging
                };

            }
            catch(Exception)
            {
                // TODO: fix me ...
                return new PagedItems<IMotorcycleDTO> { };
            }
            
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
