using Microsoft.AspNetCore.Mvc;

namespace TaxiRateApp.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
