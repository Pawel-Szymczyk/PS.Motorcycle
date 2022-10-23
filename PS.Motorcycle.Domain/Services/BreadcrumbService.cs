using PS.Motorcycle.Domain.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Services
{
    public class BreadcrumbService : IBreadcrumbService
    {


        public List<IBreadcrumb> Breadcrumbs { get; set; }


        public BreadcrumbService()
        {
            this.Breadcrumbs = new List<IBreadcrumb>();

        }

        public List<IBreadcrumb> GetBreadcrumb(IBreadcrumb breadcrumb)
        {
            if (this.Breadcrumbs.Exists(x => x.Text.Equals(breadcrumb.Text)))
                return this.Breadcrumbs;

            this.Breadcrumbs.Add(breadcrumb);

            return this.Breadcrumbs;
        }
    }
}
