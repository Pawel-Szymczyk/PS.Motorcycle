using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Application.UserPortal.UseCases.MotorcycleUseCases.AddMotorcycle;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.AdminPortal.Pages
{
    public partial class CreateMotorcyclePage : ComponentBase
    {
        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; }
        [Inject]
        private IAddMotorcycleUseCase AddMotorcyclesUseCase { get; set; }
        private List<IBreadcrumb> Breadcrumbs { get; set; }
        private IMotorcycle motorcycle;


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

        public async Task HandleValidSubmit()
        {
            // TODO: add validation
            await this.AddMotorcyclesUseCase.Execute(this.motorcycle);
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
    }
}
