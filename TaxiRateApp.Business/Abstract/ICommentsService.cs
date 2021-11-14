using System.Collections.Generic;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Business.Abstract
{
    public interface ICommentsService
    {
        IDataResult<List<Comments>> GetAllByPostsId(int postId);
        IDataResult<Comments> GetByUserId(int userId);

        IResult Add(Comments contents);
        IResult Update(Comments contents);
        IResult Delete(Comments contents);
    }
}
