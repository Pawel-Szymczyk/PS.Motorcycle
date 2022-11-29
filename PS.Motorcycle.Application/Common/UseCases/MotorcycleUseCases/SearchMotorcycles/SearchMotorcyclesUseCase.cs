using Azure.Search.Documents;
using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.DTO;
using PS.Motorcycle.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles
{
    public class SearchMotorcyclesUseCase : ISearchMotorcyclesUseCase
    {
        private readonly IAzureCognitiveSearchService _azureCognitiveSearchService;


        public SearchMotorcyclesUseCase(IAzureCognitiveSearchService azureCognitiveSearchService)
        {
            this._azureCognitiveSearchService = azureCognitiveSearchService;
        }

        //public async Task<IEnumerable<IMotorcycleDTO>> Execute(Search searchQuery)
        //{
        //    IEnumerable<IMotorcycleDTO> searchResults = await this._azureCognitiveSearchService.Query(searchQuery);

        //    return searchResults;
        //}


        public async Task<AzureCognitiveSearchData> Execute(AzureCognitiveSearchData model)
        {
            try
            {

                // Ensure the search string is valid.
                if (model.searchText == null)
                {
                    model.searchText = "";
                }

                if(string.IsNullOrEmpty(model.searchText))
                {
                    model.searchText = "*";
                }

                return await this._azureCognitiveSearchService.RunQueryAsync(model, 0, 0, "");
                
            }
            catch 
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new AzureCognitiveSearchData();
            }

        }

        

        public async Task<Dictionary<string, string>> GetMakeDictionaryAsync()
        {
            try
            {
                return await this._azureCognitiveSearchService.ExecuteMakeQueryAsync();

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new Dictionary<string, string>();
            }

        }

        public async Task<Dictionary<string, string>> GetModelDictionaryAsync(string make)
        {
            try
            {
                return await this._azureCognitiveSearchService.ExecuteModelQueryAsync(make);

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new Dictionary<string, string>();
            }

        }

        public async Task<Dictionary<int, int>> GetProductionYearDictionaryAsync()
        {
            try
            {
                return await this._azureCognitiveSearchService.ExecuteProductionYearQueryAsync();

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new Dictionary<int, int>();
            }

        }

        public async Task<Dictionary<int, int>> GetEngineCapacityDictionaryAsync()
        {
            try
            {
                return await this._azureCognitiveSearchService.ExecuteEngineCapacityQueryAsync();

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new Dictionary<int, int>();
            }

        }
        

        public async Task<AzureCognitiveSearchData> ExecuteByBodyTypeFilterAsync(AzureCognitiveSearchData model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.searchText))
                {
                    model.searchText = "*";
                }

                // Filters set by the model override those stored in temporary data.
                string filterQuery = string.Empty;

                if(model.filters.ContainsKey("bodyType"))
                {
                    BodyType bodyType;
                    Enum.TryParse(model.filters["bodyType"], out bodyType);

                    int bodyTypeInt = (int)bodyType;

                    filterQuery = this.BuildAzureSearchCognitiveFilter($"bodyType eq {bodyTypeInt}");
                }

                //int bodyType = (int)model.bodyType;
                //if(!bodyType.Equals(0))
                //{
                //    bodyTypeFilter = bodyType.ToString();
                //}

                


                return await this._azureCognitiveSearchService.RunQueryAsync(model, 0, 0, filterQuery);

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new AzureCognitiveSearchData();
            }
        }


        public async Task<AzureCognitiveSearchData> GetFilteredDataAsync(AzureCognitiveSearchData model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.searchText))
                {
                    // wildcard
                    model.searchText = "*";
                }

                string filterQuery = string.Empty;

                // ...add "make" filter...
                if (model.filters.ContainsKey("make"))
                {
                    string make = model.filters["make"];

                    filterQuery = string.Concat(filterQuery, this.BuildAzureSearchCognitiveFilter($"make eq {make}"));
                }

                // ...add "model" filter...
                if (model.filters.ContainsKey("model"))
                {
                    string modelName = model.filters["model"];

                    filterQuery = this.AddFilterConcatenation(filterQuery);
                    filterQuery = string.Concat(filterQuery, this.BuildAzureSearchCognitiveFilter($"model eq {modelName}"));
                }

                // ...add "bodyType" (facet) filter...
                if (model.filters.ContainsKey("bodyType"))
                {
                    string facet = model.filters["bodyType"];

                    filterQuery = this.AddFilterConcatenation(filterQuery);
                    filterQuery = string.Concat(filterQuery, $"bodyType eq {facet}");
                }

                // ...add "minYear" (facet) filter...
                if (model.filters.ContainsKey("minYear"))
                {
                    string facet = model.filters["minYear"];

                    filterQuery = this.AddFilterConcatenation(filterQuery);
                    filterQuery = string.Concat(filterQuery, $"year ge {facet}");
                }

                // ...add "maxYear" (facet) filter...
                if (model.filters.ContainsKey("maxYear"))
                {
                    string facet = model.filters["maxYear"];

                    filterQuery = this.AddFilterConcatenation(filterQuery);
                    filterQuery = string.Concat(filterQuery, $"year le {facet}");
                }

                // ...add "minEngineCapacity" (facet) filter...
                if (model.filters.ContainsKey("minEngineCapacity"))
                {
                    string facet = model.filters["minEngineCapacity"];

                    filterQuery = this.AddFilterConcatenation(filterQuery);
                    filterQuery = string.Concat(filterQuery, $"engine/Capacity ge {facet}");
                }

                // ...add "maxEngineCapacity" (facet) filter...
                if (model.filters.ContainsKey("maxEngineCapacity"))
                {
                    string facet = model.filters["maxEngineCapacity"];

                    filterQuery = this.AddFilterConcatenation(filterQuery);
                    filterQuery = string.Concat(filterQuery, $"engine/Capacity le {facet}");
                }

                return await this._azureCognitiveSearchService.RunQueryAsync(model, 0, 0, filterQuery);
            }
            catch (Exception)
            {
                return new AzureCognitiveSearchData();
            }
        }

        public async Task<AzureCognitiveSearchData> ExecuteFacetAsync(AzureCognitiveSearchData model)
        {
            try
            {

                // Filters set by the model override those stored in temporary data.
                string bodyTypeFilter = string.Empty;

                //if(model.bodyTypeFilter is not null)
                //    bodyTypeFilter = model.bodyTypeFilter;


                return await this._azureCognitiveSearchService.RunQueryAsync(model, 0, 0, bodyTypeFilter);

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new AzureCognitiveSearchData();
            }
        }

        /// <summary>
        /// Add "and" word to filter, which allows to join multiple filters together.
        /// </summary>
        /// <param name="filterQuery">actual filter query.</param>
        /// <returns>updated filter query by "and" at the end of query.</returns>
        private string AddFilterConcatenation(string filterQuery)
        {
            if (!string.IsNullOrEmpty(filterQuery))
            {
                filterQuery = string.Concat(filterQuery, " and ");
            }

            return filterQuery;
        }










        public async Task<AzureCognitiveSearchData> ExecutePageAsync(AzureCognitiveSearchData model)
        {
            try
            {

                int page;

                switch (model.paging)
                {
                    case "prev":
                        page = model.currentPage - 1;
                        break;

                    case "next":
                        page = model.currentPage + 1;
                        break;

                    default:
                        page = int.Parse(model.paging);
                        break;
                }

                // Recover the leftMostPage.
                int leftMostPage = model.leftMostPage;

                // Recover the filters.
                //string bodyTypeFilter = model.bodyTypeFilter;
                string bodyTypeFilter = string.Empty;

                return await this._azureCognitiveSearchService.RunQueryAsync(model, page, leftMostPage, bodyTypeFilter);

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new AzureCognitiveSearchData();
            }
        }








        private string BuildAzureSearchCognitiveFilter(FormattableString filter)
        {
            
            //string filterQuery = SearchFilter.Create($"make eq {"Suzuki"} and model eq {"Katana"}");
            string filterQuery = SearchFilter.Create(filter);

            return filterQuery;
        }





    }
}
