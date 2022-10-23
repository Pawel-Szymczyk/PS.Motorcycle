using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.AdminPortal.Pages
{
    public partial class CatalogPage : ComponentBase
    {
        //[Inject]
        //private IJSRuntime js { get; set; }

        [Inject]
        private IGetMotorcyclesUseCase GetMotorcyclesUseCase { get; set; }


        [Inject]
        private IBreadcrumbService _breadcrumbService { get; set; }

        public List<IBreadcrumb> Breadcrumbs { get; set; }

        public CatalogPage()
        {

        }

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

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if(firstRender)
        //    {
        //        await this.js.InvokeVoidAsync("hideElement");
        //        StateHasChanged();
        //    }
        //    //
        //}

        protected async ValueTask<ItemsProviderResult<IMotorcycle>> LoadMotorcycles(ItemsProviderRequest request)
        {
            var motorcycles = await this.GetMotorcyclesUseCase.Execute();
            return new ItemsProviderResult<IMotorcycle>(motorcycles.Skip(request.StartIndex).Take(request.Count), motorcycles.Count());
        }
    }
}
