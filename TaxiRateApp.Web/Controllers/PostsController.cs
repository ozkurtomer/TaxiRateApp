﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;

namespace TaxiRateApp.Web.Controllers
{
    [AllowAnonymous]
    public class PostsController : Controller
    {
        PostsManager postsManager = new PostsManager(new EfPostsDal());

        public IActionResult Index()
        {
            var result = postsManager.GetPostsHomeScreen();
            return View(result);
        }

        public IActionResult PostsDetails(int postId)
        {
            var result = postsManager.GetPostsDetailWithId(postId);
            return View(result);
        }
    }
}
