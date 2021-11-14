using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.DataAccess.EntityFramework;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.DataAccess.Concrete.EntityFramework.Context;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Concrete.EntityFramework
{
    public class EfCommentsDal : EfEntityRepositoryBase<Comments, TaxiRateAppContext>, ICommentsDal
    {
        public List<Comments> GetContentsWithDetail(Expression<Func<Comments, bool>> filter = null)
        {
            using (var context = new TaxiRateAppContext())
            {
                var result = context.Comments
                             .Include(x => x.User).Select(x => new Comments
                             {
                                 Comment_CreatedDate = x.Comment_CreatedDate,
                                 Comment_Description = x.Comment_Description,
                                 User = x.User,
                                 Post_Id = x.Post_Id,
                             }).Where(filter);

                return result.ToList();
            }
        }
    }
}
