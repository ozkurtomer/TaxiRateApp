using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;

namespace TaxiRateApp.Web.ViewComponents.Comment
{
    public class CommentListByPost : ViewComponent
    {
        CommentsManager contentsManager = new CommentsManager(new EfCommentsDal());

        public IViewComponentResult Invoke(int postId)
        {
            var result = contentsManager.GetAllByPostsId(postId);
            return View(result);
        }
    }
}
