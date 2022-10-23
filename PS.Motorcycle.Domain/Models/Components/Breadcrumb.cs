using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Domain.Models.Components
{
    public class Breadcrumb : IBreadcrumb
    {
        public string Text { get; set; }
        public string Url { get; set; }

    }
}
