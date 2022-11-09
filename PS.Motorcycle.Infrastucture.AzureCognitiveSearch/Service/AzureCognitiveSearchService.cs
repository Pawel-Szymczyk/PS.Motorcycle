using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.DTO;
using PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Interfaces;
using System.Text.Json.Serialization;

namespace PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Service
{

    public class AzureCognitiveSearchService : IAzureCognitiveSearchService
    {
        private readonly IAzureCognitiveSearchContext _azureContext;
        public AzureCognitiveSearchService(IAzureCognitiveSearchContext azureContext)
        {
            this._azureContext = azureContext;
        }

        public async Task<IEnumerable<IMotorcycleDTO>> Query(Search search)
        {

            var options = new SearchOptions()
            {
                IncludeTotalCount = true
            };

            //options.Select.Add("id");
            var response = await this._azureContext.SearchClient.SearchAsync<MotorcycleDTO>(search.SearchText, options);

            var results = response.Value.GetResults().ToList();

            List<IMotorcycleDTO> motorcycles = new List<IMotorcycleDTO>();
            foreach(var result in results)
            {
                motorcycles.Add(result.Document);
            }

            //foreach (SearchResult<Domain.Models.Motorcycle> result in response.GetResults())
            //{
            //    Domain.Models.Motorcycle doc = result.Document;
            //    motors.Add(doc);
            //}


            //search.Results = motorcycles;
            return motorcycles;
        }
    }
}
