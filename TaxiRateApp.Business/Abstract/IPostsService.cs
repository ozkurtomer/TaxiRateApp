using System.Collections.Generic;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Core.Utilities.Results.Abstract;

namespace TaxiRateApp.Business.Abstract
{
    public interface IPostsService
    {
        IDataResult<List<Posts>> GetPostsHomeScreen();
        IDataResult<List<Posts>> GetAllByUserId(int userId);
        IDataResult<Posts> GetPostsDetailWithId(int postId);
        IDataResult<List<Posts>> GetFivePosts();

        IResult Add(Posts posts);
        IResult Update(Posts posts);
        IResult Delete(Posts posts);
    }
}
