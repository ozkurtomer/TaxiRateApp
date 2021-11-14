using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.DataAccess;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Abstract
{
    public interface IPostsDal : IEntityRepository<Posts>
    {
        List<Posts> GetPostsWithDetail(Expression<Func<Posts, bool>> filter = null);
    }
}
