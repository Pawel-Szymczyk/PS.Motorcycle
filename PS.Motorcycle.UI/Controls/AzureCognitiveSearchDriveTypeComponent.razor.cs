using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class AzureCognitiveSearchDriveTypeComponent : ComponentBase
    {
        [Parameter]
        public AzureCognitiveSearchData SearchData { get; set; }


        [Parameter]
        public EventCallback<string> OnFacetClick { get; set; }

        private async Task SearchFacet(string facetName)
        {
            await this.OnFacetClick.InvokeAsync(facetName);
        }
    }
}
