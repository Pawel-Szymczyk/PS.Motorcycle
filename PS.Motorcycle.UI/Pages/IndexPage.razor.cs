using Azure.Search.Documents.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Models.DTO;
using PS.Motorcycle.Domain.Services;
using PS.Motorcycle.Domain.Types;
using PS.Motorcycle.UserPortal.ModelControls;

namespace PS.Motorcycle.UserPortal.Pages
{
    public partial class IndexPage : ComponentBase
    {
        #region Use Cases and Services ------------------------------------------
        //[Inject]
        //private IGetMotorcyclesUseCase GetMotorcyclesUseCase { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        private ISearchMotorcyclesUseCase SearchMotorcyclesUseCase { get; set; } = default!;

        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; } = default!;
        #endregion

        public List<IBreadcrumb> Breadcrumbs { get; set; }

        private int PageNo { get; set; }


        private IEnumerable<IMotorcycleDTO> searchResults;


        private AzureCognitiveSearchData searchData;

        private Dictionary<string, string> makeData;
        private Dictionary<string, string> modelData;
        private Dictionary<int, int> engineCapacityData;
        private Dictionary<int, int> yearData;
        private IDictionary<string, IList<Facet>> facetsData;

        private Dictionary<string, string> filters = new Dictionary<string, string>();

        private bool isSearchClicked;

        public IndexPage()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = "Home",
                Url = "/"
            };

            this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);

            this.searchResults = new List<IMotorcycleDTO>();

            this.makeData = new Dictionary<string, string>();
            this.modelData = new Dictionary<string, string>();
            this.yearData = new Dictionary<int, int>();
            this.engineCapacityData = new Dictionary<int, int>();
            this.facetsData = new Dictionary<string, IList<Facet>>();

            this.isSearchClicked = false;


            await this.IsLoggedInAsync();
        }

        private async Task IsLoggedInAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                this.NavigationManager.NavigateTo("/manager");
            }
        }

        protected async Task OnSearchClick(string searchPhrase)
        {
            this.filters = new Dictionary<string, string>();

            // update search input view...
            this.isSearchClicked = true;

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = searchPhrase,
            };

            this.searchData = await this.SearchMotorcyclesUseCase.Execute(model);
  
            await this.GenerateFilters(this.searchData);

            this.StateHasChanged();
        }



        /// <summary>
        /// On BodyType click (facet)
        /// </summary>
        /// <param name="bodyType"></param>
        /// <returns></returns>
        protected async Task OnBodyTypeFilterClickHandlerAsync(BodyType bodyType)
        {
            // update search input view...
            this.isSearchClicked = true;

            int bodyTypeInt = (int)bodyType;
            this.filters["bodyType"] = bodyTypeInt.ToString();

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = String.Empty,
                filters = this.filters,
            };
            this.searchData = await this.SearchMotorcyclesUseCase.Execute(model);

            await this.GenerateFilters(this.searchData);

            this.StateHasChanged();
        }


        private async Task GenerateFilters(AzureCognitiveSearchData searchData)
        {
            if (searchData != null && searchData.resultList != null)
            {
                foreach (var t in searchData.resultList.Facets)
                {
                    List<Facet> l = new List<Facet>();
                    foreach (FacetResult f in t.Value)
                    {
                        Facet x = new Facet() { ActiveFacet = false, FacetResult = f };
                        l.Add(x);
                    }
                    if (!this.facetsData.ContainsKey(t.Key))
                    {
                        this.facetsData.Add(t.Key, l);
                    }
                }
            }

            this.makeData = await this.SearchMotorcyclesUseCase.GetMakeDictionaryAsync();
            this.yearData = await this.SearchMotorcyclesUseCase.GetProductionYearDictionaryAsync();
            this.engineCapacityData = await this.SearchMotorcyclesUseCase.GetEngineCapacityDictionaryAsync();
        }


        private async Task OnFacetClickHandlerAsync(string facet)
        {
            this.searchData.searchText = string.Empty;

            this.filters["bodyType"] = facet;

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                filters = this.filters
            };

            this.searchData = await this.SearchMotorcyclesUseCase.GetFilteredDataAsync(model);
            this.StateHasChanged();
        }

        private async Task OnMakeClickHandlerAsync(string filter)
        {
            this.modelData = await this.SearchMotorcyclesUseCase.GetModelDictionaryAsync(filter);

            // clean filters first...
            this.filters = new Dictionary<string, string>();
            this.filters["make"] = filter;

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                filters = this.filters
            };

            // return results for all makes or specific make
            this.searchData = await this.SearchMotorcyclesUseCase.GetFilteredDataAsync(model);

            this.StateHasChanged();
        }

        private async Task OnModelClickHandlerAsync(string filter)
        {
            // update filter by model (filter) value.
            this.filters["model"] = filter;

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                filters = this.filters
            };

            // return results for all makes or specific make
            this.searchData = await this.SearchMotorcyclesUseCase.GetFilteredDataAsync(model);

            this.StateHasChanged();
        }


        private async Task OnMinYearChangedHandlerAsync(int year)
        {
            this.searchData.searchText = string.Empty;
            this.filters["minYear"] = year.ToString();

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                filters = this.filters
            };

            this.searchData = await this.SearchMotorcyclesUseCase.GetFilteredDataAsync(model);

            this.StateHasChanged();
        }

        private async Task OnMaxYearChangedHandlerAsync(int year)
        {
            this.searchData.searchText = string.Empty;
            this.filters["maxYear"] = year.ToString();

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                filters = this.filters
            };

            this.searchData = await this.SearchMotorcyclesUseCase.GetFilteredDataAsync(model);

            this.StateHasChanged();
        }

        private async Task OnMinEngineCapacityChangedHandlerAsync(int minEngineCapacity)
        {
            this.searchData.searchText = string.Empty;
            this.filters["minEngineCapacity"] = minEngineCapacity.ToString();

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                filters = this.filters
            };

            this.searchData = await this.SearchMotorcyclesUseCase.GetFilteredDataAsync(model);

            this.StateHasChanged();
        }

        private async Task OnMaxEngineCapacityChangedHandlerAsync(int maxEngineCapacity)
        {
            this.searchData.searchText = string.Empty;
            this.filters["maxEngineCapacity"] = maxEngineCapacity.ToString();

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                filters = this.filters
            };

            this.searchData = await this.SearchMotorcyclesUseCase.GetFilteredDataAsync(model);

            this.StateHasChanged();
        }


        private async Task OnSearchPagerClickHandlerAsync(Paging paging)
        {

            this.searchData.paging = paging.Page;
            this.searchData.searchText = paging.SearchText;

            // -----------------------------------------------
            // search update based on picked page
            // 
            int page;

            switch (this.searchData.paging)
            {
                case "prev":
                    page = PageNo - 1;
                    break;

                case "next":
                    page = PageNo + 1;
                    break;

                default:
                    page = int.Parse(this.searchData.paging);
                    break;
            }

            int leftMostPage = this.searchData.leftMostPage;

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                filters = this.searchData.filters
            };

            this.PageNo = page;

            this.searchData = await this.SearchMotorcyclesUseCase.ExecutePageAsync(model);
        }

        

 

        private async Task OnFilterResetClickHandlerAsync()
        {
            await this.OnSearchClick(string.Empty);
        }

        private async Task OnFilterRemoveClickHandlerAsync(string key)
        {
            this.filters.Remove(key);

            AzureCognitiveSearchData model = new AzureCognitiveSearchData()
            {
                searchText = string.Empty,
                filters = this.filters
            };

            // return results for all makes or specific make
            this.searchData = await this.SearchMotorcyclesUseCase.GetFilteredDataAsync(model);

            this.StateHasChanged();
        }
    }
}
