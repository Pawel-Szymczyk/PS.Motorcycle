using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using PS.Motorcycle.Application.AdminPortal.UseCases.MotorcycleUseCases.RemoveMotorcycle;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles;
using PS.Motorcycle.Common.Managers;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Models.DTO;
using PS.Motorcycle.Domain.Services;

namespace PS.Motorcycle.AdminPortal.Pages
{
    public partial class CatalogPage : ComponentBase
    {
        #region Use Cases and Services ------------------------------------------
        [Inject]
        private IGetMotorcyclesUseCase GetMotorcyclesUseCase { get; set; } = default!;

        //[Inject]
        //private ISearchMotorcyclesUseCase SearchMotorcyclesUseCase { get; set; } = default!;

        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        private IRemoveMotorcycleUseCase RemoveMotorcycleUseCase { get; set; } = default!;
        #endregion

        #region Properties ------------------------------------------------------
        private List<IBreadcrumb>? Breadcrumbs { get; set; }

        //private Virtualize<IMotorcycle> MotorcycleContainer { get; set; }

        private MotorcycleResponse<IMotorcycleDTO>? pagedItems;

        //Task<PagedItems<MotorcycleDTO>> Execute(int currentPage)

        private bool selectedRow;
        private Guid selectedRowId;
        private string editPath;



        private string messageTitle = string.Empty;
        private string message = string.Empty;
        private string messageType = string.Empty;

        private MotorcycleRequest request = null;

        private string defaultPageSize = "25";
        #endregion




        //protected override void OnInitialized()
        //{
        //    base.OnInitialized();

        //    IBreadcrumb breadcrumb = new Breadcrumb()
        //    {
        //        Text = "Home",
        //        Url = "/"
        //    };

        //    this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);

        //    //this.searchResults = new List<IMotorcycle>();

        //    var motorcycles = await this.GetMotorcyclesUseCase.Execute();
        //}

        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();

            this.selectedRow = false;


            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = "Home",
                Url = "/"
            };

            this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);

            //this.searchResults = new List<IMotorcycle>();

            this.request = new MotorcycleRequest
            {
                AscendingOrder = true,
                OrderBy = "Make",
                PageNumber = 1,
                PageSize = int.Parse(this.defaultPageSize),
                SearchPhrase = ""
            };

            this.pagedItems = await this.GetMotorcyclesUseCase.Execute(request);
        }


        //private bool selectActiveRow = false;

        //private string? ActiveRow => selectActiveRow ? "table-active" : null;

        private IMotorcycleDTO? SelectedMotorcycle { get; set; }

        private void OnClick(IMotorcycleDTO motorcycle)
        {
            this.selectedRow = true;
            this.selectedRowId = motorcycle.Id;
            this.editPath = $"manager/motorcycle/edit/{motorcycle.Id}";
        }


        protected void ClickHandler(bool agreeToDeleteMotorcycle)
        {
           

            this.RemoveMotorcycleUseCase.Execute(this.selectedRowId);

            //this.NavigationManager.NavigateTo("/");
            StateHasChanged();
        }

        protected void DeleteClickHandler(bool state)
        {
            this.messageTitle = "Delete Motorcycle";
            this.message = $"Are you sure you want to DELETE: {this.SelectedMotorcycle.Make} {this.SelectedMotorcycle.Model}?";
            this.messageType = "alert alert-danger";

            StateHasChanged();
        }


        protected async Task ReturnPageClickHandler(int pageNumber)
        {
            //MotorcycleRequest request = new MotorcycleRequest
            //{
            //    AscendingOrder = true,
            //    OrderBy = "Make",
            //    PageNumber = pageNumber,
            //    PageSize = 10,
            //    SearchPhrase = ""
            //};

            this.request.PageNumber = pageNumber;

            this.pagedItems = await this.GetMotorcyclesUseCase.Execute(request);
            StateHasChanged();
        }

        protected async Task ReturnPreviousPageClickHandler()
        {
            

            if (this.pagedItems.Paging.CurrentPage > this.pagedItems.Paging.StartPage)
            {
                //MotorcycleRequest request = new MotorcycleRequest
                //{
                //    AscendingOrder = true,
                //    OrderBy = "Make",
                //    PageNumber = (this.pagedItems.Paging.CurrentPage - 1),
                //    PageSize = 10,
                //    SearchPhrase = ""
                //};

                this.request.PageNumber = (this.pagedItems.Paging.CurrentPage - 1);

                this.pagedItems = await this.GetMotorcyclesUseCase.Execute(request);
                StateHasChanged();
            }
        }

        protected async Task ReturnNextPageClickHandler()
        {
            
            if (this.pagedItems.Paging.CurrentPage < this.pagedItems.Paging.EndPage)
            {
                //MotorcycleRequest request = new MotorcycleRequest
                //{
                //    AscendingOrder = true,
                //    OrderBy = "Make",
                //    PageNumber = (this.pagedItems.Paging.CurrentPage + 1),
                //    PageSize = 10,
                //    SearchPhrase = ""
                //};

                this.request.PageNumber = (this.pagedItems.Paging.CurrentPage + 1);

                this.pagedItems = await this.GetMotorcyclesUseCase.Execute(request);
                StateHasChanged();
            }
        }



        private async Task OnChangeSearch(ChangeEventArgs e)
        {
            string searchPhrase = e.Value as string;

            //MotorcycleRequest request = new MotorcycleRequest
            //{
            //    AscendingOrder = true,
            //    OrderBy = "Make",
            //    PageNumber = 1,
            //    PageSize = 10,
            //    SearchPhrase = searchPhrase
            //};

            this.request.SearchPhrase = searchPhrase;

            this.pagedItems = await this.GetMotorcyclesUseCase.Execute(request);
        }

        private async Task OnChangePageSize(ChangeEventArgs e)
        {
            string pageSize = e.Value as string;

            this.defaultPageSize = pageSize;

            //MotorcycleRequest request = new MotorcycleRequest
            //{
            //    AscendingOrder = true,
            //    OrderBy = "Make",
            //    PageNumber = 1,
            //    PageSize = int.Parse(pageSize),
            //    SearchPhrase = ""
            //};

            this.request.PageSize = int.Parse(pageSize);

            this.pagedItems = await this.GetMotorcyclesUseCase.Execute(request);
        }


        private void OnChangeOrder()
        {
            var x = "";
        }






        //protected async ValueTask<ItemsProviderResult<IMotorcycle>> LoadMotorcycles(ItemsProviderRequest request)
        //{
        //    //IEnumerable<IMotorcycle> motorcycles = new List<IMotorcycle>();

        //    //if (!this.searchResults.Count().Equals(0))
        //    //{
        //    //    motorcycles = this.searchResults;                
        //    //}

        //    var motorcycles = await this.GetMotorcyclesUseCase.Execute();
        //    return new ItemsProviderResult<IMotorcycle>(motorcycles.Skip(request.StartIndex).Take(request.Count), motorcycles.Count());

        //}


        //protected async Task HandleValidSubmit(Search search)
        //{
        //    if(!string.IsNullOrWhiteSpace(search.SearchText)) {
        //        this.searchResults = await this.SearchMotorcyclesUseCase.Execute(search);
        //    }
        //    else
        //    {
        //        this.searchResults = await this.GetMotorcyclesUseCase.Execute();
        //    }
        //    await this.MotorcycleContainer.RefreshDataAsync();
        //    StateHasChanged();
        //}
    }
}
