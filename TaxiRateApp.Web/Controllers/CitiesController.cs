using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;

namespace TaxiRateApp.Web.Controllers
{
    public class CitiesController : Controller
    {
        CitiesManager citiesManager = new CitiesManager(new EfCitiesDal());

        public IActionResult Index()
        {
            var result = citiesManager.GetAll();
            return View(result);
        }
    }
}
