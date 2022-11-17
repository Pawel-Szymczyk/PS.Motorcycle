using PS.Motorcycle.Application.Interfaces;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.DTO;
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

        public async Task<IEnumerable<IMotorcycleDTO>> Execute(Search searchQuery)
        {
            IEnumerable<IMotorcycleDTO> searchResults = await this._azureCognitiveSearchService.Query(searchQuery);

            return searchResults;
        }


        public async Task<SearchData> Execute(SearchData model)
        {
            try
            {

                // Ensure the search string is valid.
                if (model.searchText == null)
                {
                    model.searchText = "";
                }

                return await this._azureCognitiveSearchService.RunQueryAsync(model, 0, 0, "");
                
            }
            catch 
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new SearchData();
            }

        }

        public async Task<SearchData> ExecutePageAsync(SearchData model)
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
                string bodyTypeFilter = model.bodyTypeFilter;


                return await this._azureCognitiveSearchService.RunQueryAsync(model, page, leftMostPage, bodyTypeFilter);

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new SearchData();
            }
        }

        public async Task<SearchData> ExecuteFacetAsync(SearchData model)
        {
            try
            {

                // Filters set by the model override those stored in temporary data.
                string bodyTypeFilter = string.Empty;
                    
                if(model.bodyTypeFilter is not null)
                    bodyTypeFilter = model.bodyTypeFilter;


                return await this._azureCognitiveSearchService.RunQueryAsync(model, 0, 0, bodyTypeFilter);

            }
            catch
            {
                //return View("Error", new ErrorViewModel { RequestId = "1" });
                return new SearchData();
            }
        }

    }
}
