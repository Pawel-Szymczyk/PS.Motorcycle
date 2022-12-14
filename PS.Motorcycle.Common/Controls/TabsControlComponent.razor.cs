using Microsoft.AspNetCore.Components;

namespace PS.Motorcycle.Common.Controls
{
    public partial class TabsControlComponent : ComponentBase
    {
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
		public TabContentComponent? ActivePage { get; set; }

		private List<TabContentComponent> Pages = new List<TabContentComponent>();

		//private string imageGalleryUrls { get; set; }

		public void AddPage(TabContentComponent tabPage)
		{
			this.Pages.Add(tabPage);

			if (this.Pages.Count == 1)
				this.ActivePage = tabPage;

			StateHasChanged();
		}

		private string GetButtonClass(TabContentComponent page)
		{
			return page.Equals(this.ActivePage) ? "active" : "";
		}

		private void ActivatePage(TabContentComponent page)
		{
			this.ActivePage = page;
		}
	}
}
