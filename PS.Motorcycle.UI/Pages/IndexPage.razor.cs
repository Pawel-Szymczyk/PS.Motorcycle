using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Models.DTO;
using PS.Motorcycle.Domain.Services;
using SmartBreadcrumbs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.Pages
{
    public partial class IndexPage : ComponentBase
    {
        #region Use Cases and Services ------------------------------------------
        //[Inject]
        //private IGetMotorcyclesUseCase GetMotorcyclesUseCase { get; set; } = default!;

        [Inject]
        private ISearchMotorcyclesUseCase SearchMotorcyclesUseCase { get; set; } = default!;

        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; } = default!;
        #endregion

        public List<IBreadcrumb> Breadcrumbs { get; set; }

        private Virtualize<IMotorcycleDTO> MotorcycleContainer { get; set; }

        private IEnumerable<IMotorcycleDTO> searchResults;


        private SearchData searchData;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

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

            //this.searchData = new SearchData();
            


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

        protected async ValueTask<ItemsProviderResult<IMotorcycleDTO>> LoadMotorcycles(ItemsProviderRequest request)
        {
            //var motorcycles = await this.GetMotorcyclesUseCase.Execute();
            //return new ItemsProviderResult<IMotorcycle>(motorcycles.Skip(request.StartIndex).Take(request.Count), motorcycles.Count());
            List<IMotorcycleDTO> moto = new List<IMotorcycleDTO>();
            IEnumerable<IMotorcycleDTO> motorcycles = new List<IMotorcycleDTO>();

            //if (!this.searchResults.Count().Equals(0))
            //{
            //    motorcycles = this.searchResults;
            //}

            //if(!this.searchData.resultList.TotalCount.Equals(0))
            if (this.searchData is not null)
            {
                var x = this.searchData.resultList.GetResults().ToList();
                foreach (var item in x)
                {
                    moto.Add(item.Document);
                }
                motorcycles = (IEnumerable<IMotorcycleDTO>)moto;
            }
                

            return new ItemsProviderResult<IMotorcycleDTO>(motorcycles.Skip(request.StartIndex).Take(request.Count), motorcycles.Count());

        }


        protected async Task HandleValidSubmit(Search search)
        {
            if (!string.IsNullOrWhiteSpace(search.SearchText))
            {
                //this.searchResults = await this.SearchMotorcyclesUseCase.Execute(search);

                SearchData model = new SearchData()
                {
                    searchText = search.SearchText,
                };

                this.searchData = await this.SearchMotorcyclesUseCase.Execute(model);

            }
            else
            {
                //this.searchResults = await this.GetMotorcyclesUseCase.Execute();
            }
            //await this.MotorcycleContainer.RefreshDataAsync();
            StateHasChanged();
        }



        private async Task SearchFacet(string facetName, string searchText)
        {
            this.searchData.bodyTypeFilter = facetName;
            this.searchData.searchText = searchText;

            SearchData model = new SearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
                bodyTypeFilter = this.searchData.bodyTypeFilter,
            };

            this.searchData = await this.SearchMotorcyclesUseCase.ExecuteFacetAsync(model);
        }

        private async Task SearchPager(string paging, string searchText)
        {
            //SearchData.Paging = paging.ToString();
            //SearchData.SearchText = searchText;
            //await Search();

            this.searchData.paging = paging;
            this.searchData.searchText = searchText;

            await this.Search();
        }

        private int PageNo { get; set; }

        private async Task Search()
        {
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

            SearchData model = new SearchData()
            {
                searchText = this.searchData.searchText,
                currentPage = this.searchData.currentPage,
                pageCount = this.searchData.pageCount,
                leftMostPage = this.searchData.leftMostPage,
                pageRange = this.searchData.pageRange,
                paging = this.searchData.paging,
            };

            this.PageNo = page;

            this.searchData = await this.SearchMotorcyclesUseCase.ExecutePageAsync(model);

            

           
        }
    }
}
