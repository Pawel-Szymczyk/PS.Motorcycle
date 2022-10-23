using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class SaveButtonComponent : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private void SaveMotorcycle()
        {
            //this.NavigationManager.NavigateTo("/");
        }
    }
}
