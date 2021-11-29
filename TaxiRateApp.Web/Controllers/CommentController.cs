using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Web.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CommentAddPartial()
        {
            return PartialView();
        }

        //[HttpPost]
        //public PartialViewResult CommentAddPartial(Comments comments )
        //{

        //}

        public PartialViewResult CommentListPartial(int postId)
        {
            return PartialView();
        }
    }
}
