using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;

namespace TaxiRateApp.Web.Controllers
{
    public class PostsController : Controller
    {
        PostsManager postsManager = new PostsManager(new EfPostsDal());

        public IActionResult Index()
        {
            var result = postsManager.GetPostsWithDetail();
            return View(result);
        }
    }
}
