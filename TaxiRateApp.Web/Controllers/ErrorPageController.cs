using Microsoft.AspNetCore.Mvc;

namespace TaxiRateApp.Web.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
