using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class AzureCognitiveSearchEngineCapacityComponent : ComponentBase
    {
        [Parameter]
        public Dictionary<int, int> EngineCapacity { get; set; }

        [Parameter]
        public EventCallback<int> OnMinEngineCapacityChanged { get; set; }

        [Parameter]
        public EventCallback<int> OnMaxEngineCapacityChanged { get; set; }

        private async Task OnMinEngineCapacitySelect(ChangeEventArgs e)
        {
            int capacity = int.Parse(e.Value.ToString());
            await this.OnMinEngineCapacityChanged.InvokeAsync(capacity);
        }

        private async Task OnMaxEngineCapacitySelect(ChangeEventArgs e)
        {
            int capacity = int.Parse(e.Value.ToString());
            await this.OnMaxEngineCapacityChanged.InvokeAsync(capacity);
        }
    }
}
