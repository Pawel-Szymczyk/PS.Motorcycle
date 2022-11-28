using Azure.Search.Documents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.ModelControls
{
    public class Facet
    {
        //public IDictionary<string, IList<FacetResult>> FacetsData { get; set; }
        public FacetResult FacetResult { get; set; }
        public bool ActiveFacet { get; set; }
        public Facet()
        {
            this.ActiveFacet = false;
        }
    }
}
