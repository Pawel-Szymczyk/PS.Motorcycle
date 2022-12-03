using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Motorcycle.Domain.Types;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class PillComponent : ComponentBase
    {

        [Parameter]
        public Dictionary<string, string> Filters { get; set; }

        [Parameter]
        public EventCallback OnFilterResetClick { get; set; }

        [Parameter]
        public EventCallback<string> OnFilterRemoveClick { get; set; }

        private async Task OnFilterResetClickAsync()
        {
            await this.OnFilterResetClick.InvokeAsync();
        }

        private async Task OnFilterRemoveClickAsync(string key)
        {
            await this.OnFilterRemoveClick.InvokeAsync(key);
        }

    }
}
