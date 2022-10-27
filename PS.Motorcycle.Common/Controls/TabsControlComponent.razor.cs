using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Controls
{
    public partial class TabsControlComponent : ComponentBase
    {
		[Parameter]
		public RenderFragment ChildContent { get; set; }

		public TabContentComponent ActivePage { get; set; }

		private List<TabContentComponent> Pages = new List<TabContentComponent>();

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
