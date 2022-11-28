using Azure.Search.Documents.Models;
using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models.DTO;
using PS.Motorcycle.Domain.Types;
using PS.Motorcycle.UserPortal.ModelControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class AzureCognitiveSearchFacetComponent : ComponentBase
    {
        [Parameter]
        public IDictionary<string, IList<Facet>> FacetsData { get; set; }
        //public IDictionary<string, IList<FacetResult>> FacetsData { get; set; }


        [Parameter]
        public EventCallback<string> OnFacetClick { get; set; }



        private async Task SearchFacet(Facet facet)
        {
            // reset facets...
            foreach(var f in this.FacetsData["bodyType"])
            {
                f.ActiveFacet = false;
            }

            int facetInt = (int)facet.FacetResult.Value;
            facet.ActiveFacet = true;

            await this.OnFacetClick.InvokeAsync(facetInt.ToString());
        }
    }
}
