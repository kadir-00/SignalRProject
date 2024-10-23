using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents.DefaultCommponents
{
    public class _DefaultBookATableComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
