using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
