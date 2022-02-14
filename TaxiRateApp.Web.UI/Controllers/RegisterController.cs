using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Core.Utilities.Results.Concrete;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;
using TaxiRateApp.Entities.Dtos;
using TaxiRateApp.Web.UI.Constants;
using TaxiRateApp.Web.UI.Models;

namespace TaxiRateApp.Web.UI.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterViewModel userForRegisterViewModel)
        {
            if (!ModelState.IsValid)
                return View(userForRegisterViewModel);

            var client = Client.ClientCreate(Constant.RegisterPath, false);
            var request = Client.CreateRequest(RestSharp.Method.POST, userForRegisterViewModel);

            var result = JsonConvert.DeserializeObject<ResultModel<AccessToken>>(client.Execute(request).Content);
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(userForRegisterViewModel);
        }
    }
}
