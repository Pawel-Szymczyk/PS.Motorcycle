using Microsoft.Azure.Cosmos;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.DTO;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models.DTO;
using PS.Motorcycle.Infrastructure.CosmosDB.Interfaces;
using System.ComponentModel;

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

        public async Task<MotorcycleResponse<IMotorcycleDTO>> GetAsync(int currentPage)
        {
            try
            {
                int pageCounter = 0;
                int totalCount = 0;
                int maxItemCount = 20;

                // set additional options 
                QueryRequestOptions options = new QueryRequestOptions()
                {
                    MaxItemCount = maxItemCount
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
                var paging = new Paging(totalCount, currentPage, maxItemCount);

                return new MotorcycleResponse<IMotorcycleDTO>
                {
                    Items = items.OrderBy(item => item.CreateDate),
                    Paging = paging
                };

            }
            catch(Exception)
            {
                // TODO: fix me ...
                return new MotorcycleResponse<IMotorcycleDTO> { };
            }
            
        }





        public async Task<MotorcycleResponse<IMotorcycleDTO>> GetAsync(MotorcycleRequest request)
        {
            try
            {
                int pageCounter = 0;
                int totalCount = 0;
                //int maxItemCount = 20;

                // set additional options 
                QueryRequestOptions options = new QueryRequestOptions()
                {
                    MaxItemCount = request.PageSize
                };

                var queryDefination = new QueryDefinition("SELECT * FROM Motorcycle");
                var query = _cosmosContext.MotorcycleContainer.GetItemQueryIterator<MotorcycleDTO>(queryDefination, requestOptions: options);

                var items = new List<MotorcycleDTO>();

                // get data, count pages
                if (string.IsNullOrWhiteSpace(request.SearchPhrase))
                {
                    // get paged items
                    while (query.HasMoreResults)
                    {
                        pageCounter++;

                        var response = await query.ReadNextAsync();
                        totalCount = totalCount + response.Count();
                        if (pageCounter.Equals(request.PageNumber))
                        {
                            items.AddRange(response.ToList());
                        }
                    }
                }
                else
                {
                    // get all items 
                    while (query.HasMoreResults)
                    {
                        var response = await query.ReadNextAsync();
                        items.AddRange(response.ToList());
                    }


                    // ------------------------------------
                    // search

                    var searchItems = this.Search(items, request.SearchPhrase);

                    var newList = SplitList(searchItems, request.PageSize);

                    foreach (List<MotorcycleDTO> list in newList)
                    {
                        pageCounter++;
                        totalCount = totalCount + list.Count();
                        if (pageCounter.Equals(request.PageNumber))
                        {
                            items = list;
                        }
                    }

                }






                


                // ------------------------------------
                // order by and sorting asc / desc
                // https://stackoverflow.com/questions/1689199/c-sharp-code-to-order-by-a-property-using-the-property-name-as-a-string
                PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(MotorcycleDTO)).Find(request.OrderBy, true);
                
                if(request.AscendingOrder)
                    items = items.OrderBy(item => prop.GetValue(item)).ToList(); // ascending
                else
                    items = items.OrderByDescending(item => prop.GetValue(item)).ToList();



                // paging
                // 
                var paging = new Paging(totalCount, request.PageNumber, request.PageSize);

                return new MotorcycleResponse<IMotorcycleDTO>
                {
                    Items = items,
                    Paging = paging
                };

            }
            catch (Exception)
            {
                // TODO: fix me ...
                return new MotorcycleResponse<IMotorcycleDTO> { };
            }

        }


        public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 30)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }

        private List<MotorcycleDTO> Search(List<MotorcycleDTO> motorcycles, string searchPhrase)
        {

            List<MotorcycleDTO> list = new List<MotorcycleDTO>();
            list.AddRange(this.SearchByMake(motorcycles, searchPhrase));
            list.AddRange(this.SearchByModel(motorcycles, searchPhrase));


            return list;
        }

        private List<MotorcycleDTO> SearchByMake(List<MotorcycleDTO> motorcycles, string searchPhrase)
        {
            return motorcycles.Where(character => character.Make.Contains(searchPhrase)).ToList();
        }

        private List<MotorcycleDTO> SearchByModel(List<MotorcycleDTO> motorcycles, string searchPhrase)
        {
            return motorcycles.Where(character => character.Model.Contains(searchPhrase)).ToList();
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
