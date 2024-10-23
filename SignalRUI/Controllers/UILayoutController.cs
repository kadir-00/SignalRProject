using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.Controllers
{
	public class UILayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
