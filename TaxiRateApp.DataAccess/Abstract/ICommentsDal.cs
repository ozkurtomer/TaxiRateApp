using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using TaxiRateApp.Core.DataAccess;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Abstract
{
    public interface ICommentsDal : IEntityRepository<Comments>
    {
        List<Comments> GetContentsWithDetail(Expression<Func<Comments, bool>> filter = null);
    }
}
