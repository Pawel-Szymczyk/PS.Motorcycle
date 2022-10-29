using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.GetMotorcycles;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.UpdateMotorcycleUseCase;
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
    public partial class EditMotorcyclePage : ComponentBase
    {
        #region Parameters ------------------------------------------------------
        [Parameter]
        public Guid Id { get; set; }
        #endregion

        #region Use Cases and Services ------------------------------------------
        [Inject]
        private IBreadcrumbService? BreadcrumbService { get; set; } = default!;

        [Inject]
        private IGetMotorcycleUseCase? MotorcycleUseCase { get; set; } = default!;

        [Inject]
        private IUpdateMotorcycleUseCase? UpdateMotorcycleUseCase { get; set; } = default!;
        #endregion

        #region Properties ------------------------------------------------------
        private List<IBreadcrumb>? Breadcrumbs { get; set; }
        private IMotorcycle? motorcycle = null;
        private string path = string.Empty;
        #endregion


        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            this.motorcycle = await this.MotorcycleUseCase.Execute(this.Id);

            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = $"Edit {this.motorcycle.Make} {this.motorcycle.Model} Motorcycle",
                Url = $"/motorcycle/edit/{this.Id}"
            };

            this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);

            this.path = $"/motorcycle/{this.motorcycle.Id}";
        }

        protected async Task HandleValidSubmit()
        {
            // TODO: add validation
            if(this.motorcycle is not null)
                await this.UpdateMotorcycleUseCase.Execute(this.motorcycle);
        }
    }
}
