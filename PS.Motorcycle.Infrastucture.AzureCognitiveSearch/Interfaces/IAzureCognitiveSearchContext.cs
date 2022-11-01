using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;

namespace PS.Motorcycle.Infrastucture.AzureCognitiveSearch.Interfaces
{
    public interface IAzureCognitiveSearchContext
    {
        SearchClient SearchClient { get; set; }
        SearchIndexClient SearchIndexClient { get; set; }
    }
}