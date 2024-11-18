using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
