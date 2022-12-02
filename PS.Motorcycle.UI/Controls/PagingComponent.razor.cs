using Microsoft.AspNetCore.Components;
using PS.Motorcycle.UserPortal.ModelControls;

namespace PS.Motorcycle.UserPortal.Controls
{
    public partial class PagingComponent : ComponentBase
    {
        [Parameter]
        public int CurrentPage { get; set; }

        [Parameter]
        public int PageCount { get; set; }

        [Parameter]
        public int PageRange { get; set; }

        [Parameter]
        public int LeftMostPage { get; set; }

        [Parameter]
        public string? SearchText { get; set; }

        [Parameter]
        public EventCallback<Paging> OnSearchPagerClick { get; set; }

        private async Task OnSearchPagerClickAsync(string paging, string searchText)
        {
            var pagingObj = new Paging()
            {
                SearchText = searchText,
                Page = paging
            };

            await this.OnSearchPagerClick.InvokeAsync(pagingObj);
        }
    }
}
