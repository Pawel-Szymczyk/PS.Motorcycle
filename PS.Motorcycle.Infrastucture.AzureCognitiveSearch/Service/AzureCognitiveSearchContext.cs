using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Microsoft.Extensions.Configuration;
using PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Interfaces;

namespace PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Service
{
    public class AzureCognitiveSearchContext : IAzureCognitiveSearchContext
    {
        private readonly IConfiguration _config;
        public SearchClient SearchClient { get; set; }
        public SearchIndexClient SearchIndexClient { get; set; }
        public AzureCognitiveSearchContext(IConfiguration config)
        {
            this._config = config;

            string serviceName = this._config["AzureCognitiveSearchServiceName"];
            string indexName = this._config["AzureCognitiveSearchIndexName"];
            string apiKey = this._config["AzureCognitiveSearchApiKey"];

            // Create a SearchIndexClient to send create/delete index commands
            Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            this.SearchIndexClient = new SearchIndexClient(serviceEndpoint, credential);

            // Create a SearchClient to load and query documents
            this.SearchClient = this.SearchIndexClient.GetSearchClient(indexName);
            
        }


    }
}
