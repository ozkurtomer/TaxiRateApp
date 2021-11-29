using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using TaxiRateApp.Business.Concrete;
using TaxiRateApp.Core.Utilities.Results.Concrete;
using TaxiRateApp.DataAccess.Concrete.EntityFramework;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Web.Utilities.ClientUtilities;

namespace TaxiRateApp.Web.ViewComponents.Comment
{
    public class CommentListByPost : ViewComponent
    {
        CommentsManager contentsManager = new CommentsManager(new EfCommentsDal());

        public IViewComponentResult Invoke(int postId)
        {
            var client = CreateClient.GetClient("comment/getbypostid", false);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");

            request.AddParameter("id", postId);
            var aa = client.Execute(request).Content;
            var result = JsonConvert.DeserializeObject<SuccessDataResult<List<Comments>>>(client.Execute(request).Content);
            return View(result);
        }
    }
}
