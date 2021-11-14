using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaxiRateApp.Web.Models;

namespace TaxiRateApp.Web.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var result = new List<CommentsUser>
            {
                new CommentsUser
                {
                    Comment_Id = 1,
                    Comment_UserName = "Ömer Özkurt"
                },
                new CommentsUser
                {
                    Comment_Id = 2,
                    Comment_UserName = "Ömer Özkurt2"
                }
            };

            return View(result);
        }
    }
}
