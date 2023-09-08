using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        private readonly IDestionationService _destionationService;
        public _PopularDestinations(IDestionationService destionationService)
        {
            _destionationService = destionationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destionationService.TGetLast4Destination();
            return View(values);
        }

    }
}
