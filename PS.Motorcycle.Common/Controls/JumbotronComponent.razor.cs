using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class JumbotronComponent : ComponentBase
    {
        [Parameter]
        public string ImgUrl { get; set;}

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string SubTitle { get; set; }
    }
}
