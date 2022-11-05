using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Service
{
    public class AzureCognitiveSearchContext : IAzureCognitiveSearchContext
    {
        public SearchClient SearchClient { get; set; }
        public SearchIndexClient SearchIndexClient { get; set; }
        public AzureCognitiveSearchContext()
        {


            string serviceName = "motorcycle-search";
            string apiKey = "";
            string indexName = "cosmosdb-index";

            // Create a SearchIndexClient to send create/delete index commands
            Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            this.SearchIndexClient = new SearchIndexClient(serviceEndpoint, credential);

            // Create a SearchClient to load and query documents
            //this.SearchClient = new SearchClient(serviceEndpoint, indexName, credential);
            this.SearchClient = this.SearchIndexClient.GetSearchClient(indexName);
            
        }


    }
}
