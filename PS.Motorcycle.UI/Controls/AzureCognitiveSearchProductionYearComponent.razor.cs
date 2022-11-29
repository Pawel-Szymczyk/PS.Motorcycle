using Microsoft.AspNetCore.Components;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class AzureCognitiveSearchProductionYearComponent : ComponentBase
    {
        [Parameter]
        public Dictionary<int, int> YearData { get; set; }


        [Parameter]
        public EventCallback<int> OnMinYearChanged { get; set; }

        [Parameter]
        public EventCallback<int> OnMaxYearChanged { get; set; }

        private async Task OnMinYearSelect(ChangeEventArgs e)
        {
            int year = int.Parse(e.Value.ToString());
            await this.OnMinYearChanged.InvokeAsync(year);
        }

        private async Task OnMaxYearSelect(ChangeEventArgs e)
        {
            int year = int.Parse(e.Value.ToString());
            await this.OnMaxYearChanged.InvokeAsync(year);
        }
    }
}
