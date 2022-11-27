using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class AzureCognitiveSearchMakeComponent : ComponentBase
    {
        [Parameter]
        public Dictionary<string, string> MakeData { get; set; }

        [Parameter]
        public Dictionary<string, string> ModelData { get; set; }


        [Parameter]
        public EventCallback<string> OnMakeClick { get; set; }

        [Parameter]
        public EventCallback<string> OnModelClick { get; set; }

        private string isDisabled = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();


        }

        private async Task OnMakeSelect(ChangeEventArgs e)
        {
            string make = e.Value.ToString();
            await this.OnMakeClick.InvokeAsync(make);
        }

        private async Task OnModelSelect(ChangeEventArgs e)
        {
            string model = e.Value.ToString();
            await this.OnModelClick.InvokeAsync(model);
        }
    }
}

