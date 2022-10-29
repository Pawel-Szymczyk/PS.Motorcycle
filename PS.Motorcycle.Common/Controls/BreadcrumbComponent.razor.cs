using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models.Components;

namespace PS.Motorcycle.Common.Controls
{
    public partial class BreadcrumbComponent : ComponentBase
    {
        [Parameter]
        public List<IBreadcrumb> Breadcrumbs { get; set; }

        public BreadcrumbComponent()
        {
            this.Breadcrumbs = new List<IBreadcrumb>();
        }
    }
}
