using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class DeleteButtonComponent : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        private void OnClick()
        {
            //this.NavigationManager.NavigateTo("/create-motorcycle");
        }
    }
}
