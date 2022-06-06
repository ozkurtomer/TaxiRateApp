using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using TaxiRateApp.Core.DataAccess;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Abstract
{
    public interface IPostsDal : IEntityRepository<Posts>
    {
        Task<List<Posts>> GetPostsHomeScreen(Expression<Func<Posts, bool>> filter = null);
        Task<Posts> GetPostsDetail(int postId);
    }
}
