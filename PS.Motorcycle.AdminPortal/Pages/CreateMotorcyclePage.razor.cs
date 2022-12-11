using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Application.AdminPortal.UseCases.MotorcycleUseCases.AddMotorcycle;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Services;

namespace PS.Motorcycle.AdminPortal.Pages
{
    public partial class CreateMotorcyclePage : ComponentBase
    {
        #region Use Cases and Services ------------------------------------------
        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; } = default!;
        [Inject]
        private IAddMotorcycleUseCase AddMotorcyclesUseCase { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;
        #endregion

        #region Properties ------------------------------------------------------
        private List<IBreadcrumb> Breadcrumbs { get; set; }

        private IMotorcycle? motorcycle = null;
        #endregion

        

        public CreateMotorcyclePage()
        {
            this.motorcycle = new PS.Motorcycle.Domain.Models.Motorcycle();

            this.motorcycle.Chassis.Suspensions.Add(new Suspension() { Type = "Front", HasSuspension = true });
            this.motorcycle.Chassis.Suspensions.Add(new Suspension() { Type = "Rear", HasSuspension = true });

            this.motorcycle.Chassis.Brakes.Add(new Brake() { Type = "Front" });
            this.motorcycle.Chassis.Brakes.Add(new Brake() { Type = "Rear" });

            this.motorcycle.Chassis.Wheels.Add(new Wheel() { Type = "Front" });
            this.motorcycle.Chassis.Wheels.Add(new Wheel() { Type = "Rear" });
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = "Create Motorcycle",
                Url = "/create-motorcycle"
            };

            this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);
        }

        protected async Task HandleValidSubmit()
        {
            // TODO: add validation
            if(this.motorcycle is not null)
                await this.AddMotorcyclesUseCase.Execute(this.motorcycle);

            this.NavigationManager.NavigateTo("/manager");
        }

        
    }
}
