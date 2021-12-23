using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TaxiRateApp.Core.Utilities.Results.Concrete;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Entities.Dtos;
using TaxiRateApp.Web.Models;
using TaxiRateApp.Web.Utilities.ClientUtilities;

namespace TaxiRateApp.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserForLoginDto userForLoginDto)
        {
            var client = CreateClient.GetClient("auth/login", false);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");

            request.AddParameter("application/json", JsonConvert.SerializeObject(userForLoginDto), ParameterType.RequestBody);
            var result = JsonConvert.DeserializeObject<ResponseViewModel<AccessToken>>(client.Execute(request).Content);
            if (result.success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid,$"{result.data.UserId}")
                };
                var userIdentity = new ClaimsIdentity(claims,"a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Posts");
            }
            return View();
        }
    }
}
