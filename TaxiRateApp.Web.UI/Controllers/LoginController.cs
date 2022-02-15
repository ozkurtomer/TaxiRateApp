using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Web.UI.Constants;
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
            if (!ModelState.IsValid)
                return View(userForLoginViewModel);

            var client = Client.ClientCreate(Constant.LoginPath, false);
            var request = Client.CreateRequest(RestSharp.Method.POST, userForLoginViewModel);

            var result = JsonConvert.DeserializeObject<ResultModel<AccessToken>>(client.Execute(request).Content);
            if (result.Success)
            {
                HttpContext.Response.Cookies.Append("Token", result.Data.Token);
                return RedirectToAction("Index", "Home");
            }

            return View(userForLoginViewModel);
        }
    }
}
