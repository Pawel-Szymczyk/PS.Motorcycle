using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using PS.Motorcycle.Application.AdminPortal.UseCases.MotorcycleUseCases.RemoveMotorcycle;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.Components;
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

        private IEnumerable<IMotorcycle> motorcycles;

        private bool selectedRow;
        private Guid selectedRowId;
        private string editPath;



        private string messageTitle = string.Empty;
        private string message = string.Empty;
        private string messageType = string.Empty;


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

            this.motorcycles = await this.GetMotorcyclesUseCase.Execute();
        }


        private void OnClick(Guid id)
        {
            this.selectedRow = true;
            this.selectedRowId = id;
            this.editPath = $"manager/motorcycle/edit/{id}";
            //this.NavigationManager.NavigateTo($"/manager/motorcycle/{id}");
        }


        protected void ClickHandler(bool agreeToDeleteMotorcycle)
        {
            this.messageTitle = "Delete Motorcycle";
            //this.message = $"Are you sure you want to DELETE: {this.motorcycle.Make} {this.motorcycle.Model}?";
            this.message = $"Are you sure you want to DELETE: ?";
            this.messageType = "alert alert-danger";

            this.RemoveMotorcycleUseCase.Execute(this.selectedRowId);

            //this.NavigationManager.NavigateTo("/");
            StateHasChanged();
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
