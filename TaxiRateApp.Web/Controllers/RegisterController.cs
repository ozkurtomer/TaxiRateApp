using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Entities.Dtos;

namespace TaxiRateApp.Web.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserForRegisterDto userForRegisterDto)
        {
            var client = new RestClient($"https://localhost:44327/api/auth/register");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");

            request.AddParameter("application/json", JsonConvert.SerializeObject(userForRegisterDto), ParameterType.RequestBody);
            var result = client.Execute(request).Content;

            return RedirectToAction("Index", "Posts");
        }
    }
}
