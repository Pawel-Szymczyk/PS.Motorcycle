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

        public string? searchPhrase;

        private bool searchButtonClicked = false;

        public SearchComponent()
        {
            this.searchPhrase = string.Empty;
        }

        private async Task OnClickHandler(string searchPhrase)
        {
            this.searchButtonClicked = true;
            await this.OnSearchClick.InvokeAsync(searchPhrase);
        }

    }
}
