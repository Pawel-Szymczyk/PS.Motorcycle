using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class CardComponent : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public IMotorcycle Motorcycle { get; set; }

        public void GoToDetails()
        {

            this.NavigationManager.NavigateTo($"/motorcycle/{this.Motorcycle.Id}");
        }
    }
}
