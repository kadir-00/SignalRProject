using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.Controllers
{
	public class StatisticController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
