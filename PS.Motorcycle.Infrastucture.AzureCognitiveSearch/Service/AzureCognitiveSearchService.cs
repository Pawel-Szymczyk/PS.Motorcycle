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

        private readonly string wildcard = "*";

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

            var response = await this._azureContext.SearchClient.SearchAsync<MotorcycleDTO>(search.SearchText, options);

            var results = response.Value.GetResults().ToList();

            List<IMotorcycleDTO> motorcycles = new List<IMotorcycleDTO>();
            foreach(var result in results)
            {
                motorcycles.Add(result.Document);
            }

            return motorcycles;
        }


        // get make, model
        public async Task<Dictionary<string, string>> ExecuteMakeQueryAsync() 
        {
            var options = new SearchOptions();
            options.Select.Add("make");

            var response = await this._azureContext.SearchClient.SearchAsync<MotorcycleDTO>(this.wildcard, options);

            var results = response.Value.GetResults().ToList();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            try
            {
                foreach (var result in results)
                {
                    dictionary.Add(result.Document.Make, result.Document.Make);
                }
            }
            catch
            {

            }

            return dictionary;
        }

        public async Task<Dictionary<string, string>> ExecuteModelQueryAsync(string make)
        {
            if(string.IsNullOrEmpty(make))
                return new Dictionary<string, string>();

            var options = new SearchOptions();
            options.Filter = $"make eq '{make}'";
            options.Select.Add("model");

            var response = await this._azureContext.SearchClient.SearchAsync<MotorcycleDTO>(make, options);

            var results = response.Value.GetResults().ToList();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            try
            {
                foreach (var result in results)
                {
                    dictionary.Add(result.Document.Model, result.Document.Model);
                }
            }
            catch
            {

            }

            return dictionary;
        }

        public async Task<Dictionary<int, int>> ExecuteProductionYearQueryAsync()
        {
            var options = new SearchOptions();
            options.Select.Add("year");

            var response = await this._azureContext.SearchClient.SearchAsync<MotorcycleDTO>(this.wildcard, options);

            var results = response.Value.GetResults().ToList();

            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            try
            {
                foreach (var result in results)
                {
                    if(!dictionary.ContainsKey(result.Document.Year))
                        dictionary.Add(result.Document.Year, result.Document.Year);
                }
            }
            catch
            {

            }

            return dictionary.OrderBy(x=>x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public async Task<Dictionary<int, int>> ExecuteEngineCapacityQueryAsync()
        {
            var options = new SearchOptions();
            options.Select.Add("engine/Capacity");

            var response = await this._azureContext.SearchClient.SearchAsync<MotorcycleDTO>(this.wildcard, options);

            var results = response.Value.GetResults().ToList();

            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            try
            {
                foreach (var result in results)
                {
                    if (!dictionary.ContainsKey(result.Document.Engine.Capacity))
                        dictionary.Add(result.Document.Engine.Capacity, result.Document.Engine.Capacity);
                }
            }
            catch
            {

            }

            return dictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }


        public async Task<AzureCognitiveSearchData> RunQueryAsync(AzureCognitiveSearchData model, int page, int leftMostPage, string filterQuery)
        {
            //string facetFilter = "";


            //if(bodyTypeFilter.Length > 0)
            //{
            //    // One, or zero, facets apply.
            //    facetFilter = $"bodyType eq {bodyTypeFilter}";
            //}


            var options = new SearchOptions()
            {
                //Filter = facetFilter,
                //Filter = "bodyType eq 1",
                //Filter = SearchFilter.Create($"make eq {"Suzuki"} and model eq {"Katana"}"),
                Filter = filterQuery,

                SearchMode = SearchMode.All,

                // Skip past results that have already been returned.
                Skip = page * GlobalVariables.ResultsPerPage,

                // Take only the next page worth of results.
                Size = GlobalVariables.ResultsPerPage,

                // Include the total number of results.
                IncludeTotalCount = true
            };

            // Return information on the text, and number, of facets in the data.
            options.Facets.Add("bodyType,count:0");

            //options.Facets.Add("make,count:0");
            //options.Facets.Add("model,count:0");


            // Enter MotorcycleDTO property names into this list so only these values will be returned.
            // If Select is empty, all values will be returned, which can be inefficient.
            options.Select.Add("id");
            options.Select.Add("year");
            options.Select.Add("make");
            options.Select.Add("model");
            options.Select.Add("bodyType");
            options.Select.Add("imageUrl");
            options.Select.Add("logoUrl");

            options.Select.Add("engine/Capacity");

            

            // For efficiency, the search call should be asynchronous, so use SearchAsync rather than Search.
            model.resultList = await this._azureContext.SearchClient.SearchAsync<MotorcycleDTO>(model.searchText, options);

            // This variable communicates the total number of pages to the view.
            model.pageCount = ((int)model.resultList.TotalCount + GlobalVariables.ResultsPerPage - 1) / GlobalVariables.ResultsPerPage;

            // This variable communicates the page number being displayed to the view.
            model.currentPage = page;

            // Calculate the range of page numbers to display.
            if (page == 0)
            {
                leftMostPage = 0;
            }
            else if (page <= leftMostPage)
            {
                // Trigger a switch to a lower page range.
                leftMostPage = Math.Max(page - GlobalVariables.PageRangeDelta, 0);
            }
            else if (page >= leftMostPage + GlobalVariables.MaxPageRange - 1)
            {
                // Trigger a switch to a higher page range.
                leftMostPage = Math.Min(page - GlobalVariables.PageRangeDelta, model.pageCount - GlobalVariables.MaxPageRange);
            }
            model.leftMostPage = leftMostPage;

            // Calculate the number of page numbers to display.
            model.pageRange = Math.Min(model.pageCount - leftMostPage, GlobalVariables.MaxPageRange);


            return model;
        }
    }
}
