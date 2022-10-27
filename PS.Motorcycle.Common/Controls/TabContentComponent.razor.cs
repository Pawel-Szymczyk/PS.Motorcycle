using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class TabContentComponent : ComponentBase
    {
        [CascadingParameter]
        private TabsControlComponent Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string ImgUrl { get; set; }


        protected override void OnInitialized()
        {
            if (this.Parent == null)
                throw new ArgumentNullException(nameof(this.Parent), "TabContentComponent must exist within a TabsControlComponent");


            base.OnInitialized();

            this.Parent.AddPage(this);
        }
    }
}
