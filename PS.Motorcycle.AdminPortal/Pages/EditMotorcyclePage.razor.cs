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
    public partial class EditMotorcyclePage : ComponentBase
    {
        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        private IBreadcrumbService BreadcrumbService { get; set; }
        private List<IBreadcrumb> Breadcrumbs { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            IBreadcrumb breadcrumb = new Breadcrumb()
            {
                Text = $"Edit Motorcycle",
                Url = $"/motorcycle/edit/{this.Id}"
            };

            this.Breadcrumbs = this.BreadcrumbService.GetBreadcrumb(breadcrumb);
        }
    }
}
