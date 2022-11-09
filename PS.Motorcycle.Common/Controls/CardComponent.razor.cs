using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Interfaces;
using PS.Motorcycle.Domain.Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class CardComponent : ComponentBase
    {
        [Parameter]
        public IMotorcycleDTO? Motorcycle { get; set; }

        [Parameter]
        public string? Path { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        private void OnClick()
        {
            this.NavigationManager.NavigateTo($"{this.Path}");
        }
    }
}
