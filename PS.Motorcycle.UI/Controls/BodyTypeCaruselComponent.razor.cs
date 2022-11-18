using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PS.Motorcycle.Domain.Models.DTO;
using PS.Motorcycle.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class BodyTypeCaruselComponent : ComponentBase
    {

        [Parameter]
        public EventCallback<BodyType> OnBodyTypeClick { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; } = default!;

        private bool firstRender = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await this.JS.InvokeAsync<object>("initializeSearchCarousel");

                this.firstRender = false;
            }
        }


        private async Task OnClickHandler(BodyType bodyType) 
        {
            await this.OnBodyTypeClick.InvokeAsync(bodyType);
        }
    }
}
