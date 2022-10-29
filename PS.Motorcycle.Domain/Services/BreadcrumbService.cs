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
            // remove pages that does not belong to the breadcrumbs sequence
            int currentPageIndex = this.Breadcrumbs.FindIndex(x => x.Text.Contains(breadcrumb.Text));
   
            if (this.Breadcrumbs.Exists(x => x.Text.Equals(breadcrumb.Text)))
            {
                // remove pages up to the current page (from latest to oldest)
                for (int index = this.Breadcrumbs.Count - 1; index > currentPageIndex; index--)
                {
                    this.Breadcrumbs.RemoveAt(index);
                }
                return this.Breadcrumbs;
            }


            // do not add breadcrumb if already exists on the list
            if (this.Breadcrumbs.Exists(x => x.Text.Equals(breadcrumb.Text)))
                return this.Breadcrumbs;


            // add breadcrumb 
            this.Breadcrumbs.Add(breadcrumb);

            return this.Breadcrumbs;
        }
    }
}
