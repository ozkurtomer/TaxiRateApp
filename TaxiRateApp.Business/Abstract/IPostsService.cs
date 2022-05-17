using System.Threading.Tasks;
using System.Collections.Generic;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Core.Utilities.Results.Abstract;

namespace TaxiRateApp.Business.Abstract
{
    public interface IPostsService
    {
        Task<IDataResult<List<Posts>>> GetPostsHomeScreen();
        Task<IDataResult<List<Posts>>> GetAllByUserId(int userId);
        Task<IDataResult<Posts>> GetPostsDetailWithId(int postId);
        Task<IDataResult<List<Posts>>> GetFivePosts();
        Task<IDataResult<List<Posts>>> GetPostWithPlateNo(string plateNo);

        Task<IResult> Add(Posts posts);
        Task<IResult> Update(Posts posts);
        Task<IResult> Delete(Posts posts);
    }
}
