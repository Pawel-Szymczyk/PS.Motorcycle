using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
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

        [Inject]
        private ISearchMotorcyclesUseCase SearchMotorcyclesUseCase { get; set; } = default!;

        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; } = default!;
        #endregion

        #region Properties ------------------------------------------------------
        private List<IBreadcrumb>? Breadcrumbs { get; set; }


        private Search? searchData;
        #endregion

        protected override void OnInitialized()
        {
            base.OnInitialized();

            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = "Home",
                Url = "/"
            };

            this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);


            this.searchData = new Search();
        }

        protected async Task SearchAsync()
        {
           await this.SearchMotorcyclesUseCase.Execute();
        }

        protected async ValueTask<ItemsProviderResult<IMotorcycle>> LoadMotorcycles(ItemsProviderRequest request)
        {
            var motorcycles = await this.GetMotorcyclesUseCase.Execute();
            return new ItemsProviderResult<IMotorcycle>(motorcycles.Skip(request.StartIndex).Take(request.Count), motorcycles.Count());
        }


        protected async Task HandleValidSubmit(Search search)
        {
            this.searchData = search;
        }
    }
}
