using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;

namespace TaxiRateApp.Web.UI.Controllers
{
    public class PostsController : Controller
    {
        PostsManager postsManager = new PostsManager(new EfPostsDal());
        public IActionResult PostList()
        {
            var model = postsManager.GetPostsHomeScreen();
            return View(model);
        }
    }
}
