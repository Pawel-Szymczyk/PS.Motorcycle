using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
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

        public async Task Query()
        {

            var options = new SearchOptions()
            {
                IncludeTotalCount = true
            };

            //options.Select.Add("id");
            var response = await this._azureContext.SearchClient.SearchAsync<PS.Motorcycle.Domain.Models.Motorcycle>("*", options);

            var x = response.Value.GetResults().ToList();

            List<Domain.Models.Motorcycle> motors = new List<Domain.Models.Motorcycle>();
            //foreach (SearchResult<Domain.Models.Motorcycle> result in response.GetResults())
            //{
            //    Domain.Models.Motorcycle doc = result.Document;
            //    motors.Add(doc);
            //}

        }
    }
}
