using Microsoft.AspNetCore.Mvc;

namespace TaxiRateApp.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
