using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgencyCoreProject.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        FeatureManager featureManager1 = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values = featureManager1.TGetList();
            return View(values);
        }
    }
}
