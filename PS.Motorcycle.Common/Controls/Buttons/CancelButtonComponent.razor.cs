using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls.Buttons
{
    public partial class CancelButtonComponent : ComponentBase
    {
        [Parameter]
        public string? Path { get; set; }

        [Parameter]
        public string? Text { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        private void OnClick()
        {
            this.NavigationManager.NavigateTo($"{this.Path}");
        }
    }
}
