using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents.DefaultCommponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
