using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents.MenuComponents
{
    public class _MenuNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
        return View();
        }
    }
}
