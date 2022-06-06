using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaxiRateApp.Core.DataAccess.EntityFramework;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.DataAccess.Concrete.EntityFramework.Context;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Concrete.EntityFramework
{
    public class EfPostsDal : EfEntityRepositoryBase<Posts, TaxiRateAppContext>, IPostsDal
    {
        public async Task<Posts> GetPostsDetail(int postId)
        {
            using (TaxiRateAppContext context = new TaxiRateAppContext())
            {
                var result = context.Posts.Include(x => x.User).Include(x => x.City).Include(x => x.Comments).Select(x => new Posts
                {
                    Post_Id = x.Post_Id,
                    City = x.City,
                    Post_CreatedDate = x.Post_CreatedDate,
                    Post_Description = x.Post_Description,
                    Post_Plate = x.Post_Plate,
                    Post_Stars = x.Post_Stars,
                    Post_LikeCount = x.Post_LikeCount,
                    Post_Title = x.Post_Title,
                    Comments = x.Comments.Select(y=>new Comments
                    {
                          Post_Id=y.Post_Id,
                          User_Id=y.User_Id,
                          Comment_CreatedDate=y.Comment_CreatedDate,
                          Comment_Description=y.Comment_Description,
                          Comment_Id=y.Comment_Id,
                          Comment_IsActive=y.Comment_IsActive,
                          User = y.User
                    }).ToList(),
                    User = x.User,
                    City_Id = x.City_Id,
                    Post_IsActive = x.Post_IsActive,
                    User_Id = x.User_Id
                }).Where(x => x.Post_Id == postId);
                return result.FirstOrDefault();
            }
        }

        public async Task<List<Posts>> GetPostsHomeScreen(Expression<Func<Posts, bool>> filter = null)
        {
            using (TaxiRateAppContext context = new TaxiRateAppContext())
            {
                if (filter == null)
                {
                    var result = context.Posts.Include(x => x.User).Include(x => x.City).Select(x => new Posts
                    {
                        Post_Id = x.Post_Id,
                        City = x.City,
                        Post_CreatedDate = x.Post_CreatedDate,
                        Post_Description = x.Post_Description,
                        Post_Plate = x.Post_Plate,
                        Post_Stars = x.Post_Stars,
                        Post_LikeCount = x.Post_LikeCount,
                        Post_Title = x.Post_Title
                    });
                    return result.ToList();
                }

                else
                {
                    var result = context.Posts.Include(x => x.User).Include(x => x.City);

                    return result.Where(filter).ToList();
                }
            }
        }

    }
}
