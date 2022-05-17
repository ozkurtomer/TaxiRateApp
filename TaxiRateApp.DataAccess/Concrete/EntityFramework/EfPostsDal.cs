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
                        Post_LikeCount = x.Post_LikeCount
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
