using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Common.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class MessagePopupComponent : ComponentBase
    {
        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Message { get; set; }

        [Parameter]
        public string? Type { get; set; }

        [Parameter] 
        public EventCallback<bool> OnClick { get; set; }






        //[Inject]
        //public EventManager EventManager { get; set; }

        protected override void OnInitialized()
        {

            base.OnInitialized();

            //this.EventManager.OnDeleteChangeEvent += this.OnDeleteChangeEventHandler;
        }

        //public void Dispose()
        //{
        //    this.EventManager.OnDeleteChangeEvent -= this.OnDeleteChangeEventHandler;
        //}

        //private async void OnDeleteChangeEventHandler(object sender, DeleteChangeEventArgs args)
        //{
        //    await InvokeAsync(() => {
        //        StateHasChanged();
        //    });
        //}

    }
}
