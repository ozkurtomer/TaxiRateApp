using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;

namespace TaxiRateApp.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        PostsManager postsManager = new PostsManager(new EfPostsDal());

        public IActionResult Index()
        {
            var result = postsManager.GetPostsHomeScreen();
            return View(result);
        }
    }
}
