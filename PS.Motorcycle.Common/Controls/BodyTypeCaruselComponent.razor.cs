using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class BodyTypeCaruselComponent : ComponentBase
    {

        [Inject]
        public IJSRuntime JS { get; set; } = default!;

        private bool firstRender = true;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //if (!this.Images.Count.Equals(0))
                //{
                //    await this.JS.InvokeAsync<object>("initializeSlides");
                //}

                await this.JS.InvokeAsync<object>("initializeSearchCarousel");

                this.firstRender = false;
            }
        }
    }
}
