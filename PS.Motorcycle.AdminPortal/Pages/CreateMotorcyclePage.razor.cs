using Microsoft.AspNetCore.Components;
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
