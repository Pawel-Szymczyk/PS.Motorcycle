using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.SearchMotorcycles;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.Components;
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
        [Inject]
        private IGetMotorcyclesUseCase GetMotorcyclesUseCase { get; set; } = default!;

        [Inject]
        private ISearchMotorcyclesUseCase SearchMotorcyclesUseCase { get; set; } = default!;

        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; } = default!;
        #endregion

        public List<IBreadcrumb> Breadcrumbs { get; set; }

        private Virtualize<IMotorcycle> MotorcycleContainer { get; set; }

        private IEnumerable<IMotorcycle> searchResults;

        public IndexPage()
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

            this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);

            this.searchResults = new List<IMotorcycle>();
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
            //var motorcycles = await this.GetMotorcyclesUseCase.Execute();
            //return new ItemsProviderResult<IMotorcycle>(motorcycles.Skip(request.StartIndex).Take(request.Count), motorcycles.Count());

            IEnumerable<IMotorcycle> motorcycles = new List<IMotorcycle>();

            if (!this.searchResults.Count().Equals(0))
            {
                motorcycles = this.searchResults;
            }

            return new ItemsProviderResult<IMotorcycle>(motorcycles.Skip(request.StartIndex).Take(request.Count), motorcycles.Count());

        }


        protected async Task HandleValidSubmit(Search search)
        {
            if (!string.IsNullOrWhiteSpace(search.SearchText))
            {
                this.searchResults = await this.SearchMotorcyclesUseCase.Execute(search);
            }
            else
            {
                this.searchResults = await this.GetMotorcyclesUseCase.Execute();
            }
            await this.MotorcycleContainer.RefreshDataAsync();
            StateHasChanged();
        }
    }
}
