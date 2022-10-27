using Microsoft.AspNetCore.Components;
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
    public partial class MotorcycleDetailsPage : ComponentBase
    {

        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        [Inject]
        private IGetMotorcycleUseCase MotorcycleUseCase { get; set; }
        private IMotorcycle motorcycle;
        private bool firstRender = true;

        [Inject]
        private IBreadcrumbService _breadcrumbService { get; set; }
        public List<IBreadcrumb> Breadcrumbs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            this.motorcycle = await this.MotorcycleUseCase.Execute(this.Id);



            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = $"{this.motorcycle.Make} / {this.motorcycle.Model}",
                Url = $"/motorcycle/{this.motorcycle.Id}"
            };

            this.Breadcrumbs = this._breadcrumbService.GetBreadcrumb(breadcrumb);

            
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await this.JS.InvokeAsync<object>("initializeCarousel");
                this.firstRender = false; 
            }
        }






    }
}
