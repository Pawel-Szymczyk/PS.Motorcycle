using Microsoft.AspNetCore.Components;
using PS.Motorcycle.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class SearchComponent : ComponentBase
    {
        [Parameter]
        public EventCallback<string> OnSearchClick { get; set; }

        [Parameter]
        public bool IsClicked { get; set; }

        public string? searchPhrase;


        public SearchComponent()
        {
            this.searchPhrase = string.Empty;
        }

        private async Task OnClickHandler(string searchPhrase)
        {
            await this.OnSearchClick.InvokeAsync(searchPhrase);
        }

    }
}
