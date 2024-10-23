using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.Controllers
{
	public class ProgressBarsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
