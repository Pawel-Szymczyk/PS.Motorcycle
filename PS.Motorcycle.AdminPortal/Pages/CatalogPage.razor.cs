using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.AdminPortal.Pages
{
    public partial class CatalogPage : ComponentBase
    {
        [Inject]
        private IJSRuntime js { get; set; }

        [Inject]
        private IGetMotorcyclesUseCase GetMotorcyclesUseCase { get; set; }

        public CatalogPage()
        {

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
