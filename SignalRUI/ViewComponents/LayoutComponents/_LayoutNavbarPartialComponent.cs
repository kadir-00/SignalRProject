using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{ 
		return View();
		}
	}
}
