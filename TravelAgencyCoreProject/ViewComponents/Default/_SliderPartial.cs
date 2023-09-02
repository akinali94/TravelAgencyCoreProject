using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View(); 
        }
    }
}
