﻿using Microsoft.AspNetCore.Components;
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
    public partial class CreateMotorcyclePage
    {
        public IMotorcycle motorcycle;

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

        public void HandleValidSubmit()
        {

            var x = this.motorcycle;
        }

       










        private bool tab1 = true;
        private bool tab2 = false;
        private bool tab3 = false;
        private bool tab4 = false;
        private bool tab5 = false;

        private void DisplayTab(int TabNumber)
        {
            switch(TabNumber)
            {
                case 1:
                    this.tab1 = true;
                    this.tab2 = false;
                    this.tab3 = false;
                    this.tab4 = false;
                    this.tab5 = false;
                    break;
                case 2:
                    this.tab1 = false;
                    this.tab2 = true;
                    this.tab3 = false;
                    this.tab4 = false;
                    this.tab5 = false;
                    break;
                case 3:
                    this.tab1 = false;
                    this.tab2 = false;
                    this.tab3 = true;
                    this.tab4 = false;
                    this.tab5 = false;
                    break;
                case 4:
                    this.tab1 = false;
                    this.tab2 = false;
                    this.tab3 = false;
                    this.tab4 = true;
                    this.tab5 = false;
                    break;
                case 5:
                    this.tab1 = false;
                    this.tab2 = false;
                    this.tab3 = false;
                    this.tab4 = false;
                    this.tab5 = true;
                    break;
            }
         }



        [Inject]
        private IBreadcrumbService _breadcrumbService { get; set; }

        public List<IBreadcrumb> Breadcrumbs { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = "Create Motorcycle",
                Url = "/create-motorcycle"
            };

            this.Breadcrumbs = this._breadcrumbService.GetBreadcrumb(breadcrumb);
        }
    }
}