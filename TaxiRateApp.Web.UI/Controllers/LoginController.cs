using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Web.UI.Models;

namespace TaxiRateApp.Web.UI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginViewModel userForLoginViewModel)
        {
            if (ModelState.IsValid)
                return View(userForLoginViewModel);

            return View();
        }
    }
}
