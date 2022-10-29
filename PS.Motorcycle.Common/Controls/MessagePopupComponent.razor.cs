using Microsoft.AspNetCore.Components;
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

    }
}
