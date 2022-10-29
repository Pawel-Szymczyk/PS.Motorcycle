using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class SlideshowGalleryComponent : ComponentBase
    {
        [Parameter]
        public List<string>? Images { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; } = default!;

        private bool firstRender = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if(!this.Images.Count.Equals(0))
                {
                    await this.JS.InvokeAsync<object>("initializeSlides");
                }

                this.firstRender = false;
            }
        }

        public async Task PlusSlides(int direction)
        {
            await this.JS.InvokeVoidAsync("plusSlides", direction);
        }

        public async Task CurrentSlide(int number)
        {
            await this.JS.InvokeVoidAsync("currentSlide", number);
        }
    }
}
