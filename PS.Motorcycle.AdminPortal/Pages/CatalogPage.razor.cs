using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Domain.Interfaces;
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
        private IBreadcrumbService _breadcrumbService { get; set; } = default!;
        #endregion

        #region Properties ------------------------------------------------------
        private List<IBreadcrumb>? Breadcrumbs { get; set; }
        #endregion

        protected override void OnInitialized()
        {
            base.OnInitialized();

            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = "Home",
                Url = "/"
            };

            this.Breadcrumbs = this._breadcrumbService.GetBreadcrumb(breadcrumb);
        }

        protected async ValueTask<ItemsProviderResult<IMotorcycle>> LoadMotorcycles(ItemsProviderRequest request)
        {
            var motorcycles = await this.GetMotorcyclesUseCase.Execute();
            return new ItemsProviderResult<IMotorcycle>(motorcycles.Skip(request.StartIndex).Take(request.Count), motorcycles.Count());
        }
    }
}
