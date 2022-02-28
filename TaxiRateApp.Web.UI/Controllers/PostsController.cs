using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;
using TaxiRateApp.Web.UI.ViewModels;

namespace TaxiRateApp.Web.UI.Controllers
{
    public class PostsController : Controller
    {
        PostsManager postsManager = new PostsManager(new EfPostsDal());
        CitiesManager citiesManager = new CitiesManager(new EfCitiesDal());
        public IActionResult PostList()
        {
            var model = postsManager.GetPostsHomeScreen();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            var model = new AddPostViewModel
            {
                Post = new Entities.Concrete.Posts(),
                City = citiesManager.GetAll().Data,
            };
            return View(model);
        }
    }
}
