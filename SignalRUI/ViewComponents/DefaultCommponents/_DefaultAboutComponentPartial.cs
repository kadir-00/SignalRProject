using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents.DefaultCommponents
{
    public class _DefaultAboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
