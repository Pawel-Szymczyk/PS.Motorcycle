using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class AzureCognitiveSearchProductionYearComponent : ComponentBase
    {
        [Parameter]
        public Dictionary<string, string> YearData { get; set; }


        [Parameter]
        public EventCallback<string> OnFacetClick { get; set; }

        private async Task OnMinYearSelect(ChangeEventArgs e)
        {
            string make = e.Value.ToString();
            //await this.OnMakeClick.InvokeAsync(make);
        }

        private async Task OnMaxYearSelect(ChangeEventArgs e)
        {
            string make = e.Value.ToString();
            //await this.OnMakeClick.InvokeAsync(make);
        }
    }
}
