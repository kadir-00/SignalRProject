using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents.DefaultCommponents
{
    public class _DefaultSliderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
