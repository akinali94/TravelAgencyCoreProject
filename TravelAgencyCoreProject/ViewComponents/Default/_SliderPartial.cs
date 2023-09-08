using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        private readonly IDestionationService _destServ;

        public _SliderPartial(IDestionationService destServ)
        {
            _destServ = destServ;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destServ.TGetList();
            return View(values); 
        }

    }
}
