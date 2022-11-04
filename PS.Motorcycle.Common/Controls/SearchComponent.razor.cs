using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class SearchComponent : ComponentBase
    {
        [Parameter]
        public EventCallback<Search> OnHandleValidSubmit { get; set; }

        //[Parameter]
        public Search? search;

        public SearchComponent()
        {
            this.search = new Search();
        }


    }
}
