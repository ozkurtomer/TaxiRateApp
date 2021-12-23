using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.Business.ValidationRules.FluentValidation;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Entities.Dtos;
using TaxiRateApp.Web.Utilities.ClientUtilities;

namespace TaxiRateApp.Web.Controllers
{
    [AllowAnonymous]
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
            RegisterValidator registerValidator = new RegisterValidator();
            ValidationResult validationResult = registerValidator.Validate(userForRegisterDto);
            if (validationResult.IsValid)
            {
                var client = CreateClient.GetClient("auth/register", false);
                var request = new RestRequest(Method.POST);
                request.AddHeader("content-type", "application/json");

                request.AddParameter("application/json", JsonConvert.SerializeObject(userForRegisterDto), ParameterType.RequestBody);
                var result = client.Execute(request).Content;

                return RedirectToAction("Index", "Posts");
            }

            foreach (var item in validationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
    }
}
