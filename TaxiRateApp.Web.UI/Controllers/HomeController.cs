using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        PostsManager postsManager = new PostsManager(new EfPostsDal());

        public IActionResult Index()
        {
            //var result = postsManager.GetPostsHomeScreen();
            //return View(result);
            return View();
        }
    }
}
