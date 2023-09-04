using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.MemberDashboard
{
    public class _LastDestinations : ViewComponent
    {
        private readonly IDestionationService _destionationService;
        public _LastDestinations(IDestionationService destionationService)
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
