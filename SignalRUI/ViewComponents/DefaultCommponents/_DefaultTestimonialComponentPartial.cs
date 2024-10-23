using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents.DefaultCommponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
