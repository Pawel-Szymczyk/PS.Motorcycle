using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Common.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls.Buttons
{
    public partial class DeleteButtonComponent : ComponentBase
    {
        [Parameter]
        public EventCallback<bool> OnClick { get; set; }

        //[Inject]
        //public EventManager EventManager { get; set; }

        //private void OnClick()
        //{
        //    this.EventManager.RequestDeletionOfMotorcycle(true);
        //}






















        //[Inject]
        //private NavigationManager NavigationManager { get; set; } = default!;

        //private void OnClick()
        //{
        //    this.NavigationManager.NavigateTo($"{this.Path}");
        //}
    }
}
