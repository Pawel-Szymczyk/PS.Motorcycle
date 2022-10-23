using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models.Components;
using PS.Motorcycle.Domain.Services;

namespace PS.Motorcycle.Common.Controls
{
    public partial class BreadcrumbComponent : ComponentBase
    {
        //[Inject]
        //protected IBreadcrumbService _breadcrumbService { get; set; }


        [Parameter]
        public List<IBreadcrumb> Breadcrumbs { get; set; }

        //[Parameter]
        //public IBreadcrumb Breadcrumb { get; set; }

        public BreadcrumbComponent()
        {

        }

        //public BreadcrumbComponent(IBreadcrumbService breadcrumbService)
        //{
        //    this._breadcrumbService = breadcrumbService;

        //    //this.Breadcrumbs = new List<IBreadcrumb>();
        //    //if(this.Breadcrumb != null)
        //    //{
        //    //    this.Breadcrumbs.Add(this.Breadcrumb);

        //    //}
        //}
    }
}
