using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
