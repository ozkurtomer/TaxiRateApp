using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Web.Controllers
{
    public class CommentController : Controller
    {
        CommentsManager commentsManager = new CommentsManager(new EfCommentsDal());

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CommentAddPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult CommentAddPartial(Comments comments)
        {
            comments.User_Id = 1;
            comments.Post_Id = 1;
            comments.Comment_CreatedDate = System.DateTime.Now;
            comments.Comment_IsActive = false;
            commentsManager.Add(comments);

            return PartialView();
        }

        public PartialViewResult CommentListPartial(int postId)
        {
            return PartialView();
        }
    }
}
