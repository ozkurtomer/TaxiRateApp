using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;

namespace TaxiRateApp.Web.Controllers
{
    public class CommentController : Controller
    {
        CommentsManager contentsManager = new CommentsManager(new EfCommentsDal());

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult CommentAddPartial()
        {
            return PartialView();
        }

        public PartialViewResult CommentListPartial(int postId)
        {
            return PartialView();
        }
    }
}
