using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Business.Constants;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Core.Utilities.Results.Concrete;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Business.Concrete
{
    public class PostsManager : IPostsService
    {
        IPostsDal _postsDal;

        public PostsManager(IPostsDal postsDal)
        {
            _postsDal = postsDal;
        }

        public async Task<IResult> Add(Posts posts)
        {
            try
            {
                await _postsDal.Add(posts);
                return new SuccessResult(Messages.PostAdded);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> Update(Posts posts)
        {
            try
            {
                await _postsDal.Update(posts);
                return new SuccessResult(Messages.PostUpdated);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> Delete(Posts posts)
        {
            try
            {
                await _postsDal.Delete(posts);
                return new SuccessResult(Messages.PostDeleted);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<Posts>>> GetAll()
        {
            try
            {
                var result = await _postsDal.GetAll();
                var resultOfSelect = result.Select(x => new Posts
                {
                    City = x.City,
                    City_Id = x.City_Id,
                    Post_CreatedDate = x.Post_CreatedDate,
                    Post_Description = $"{x.Post_Description.Substring(0, 7)}...",
                    Post_Id = x.Post_Id,
                    Post_IsActive = x.Post_IsActive,
                    Post_Plate = x.Post_Plate,
                    Post_Stars = x.Post_Stars,
                    User_Id = x.User_Id,
                    Post_Title = x.Post_Title
                }).ToList();
                return new SuccessDataResult<List<Posts>>(resultOfSelect, Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Posts>>> GetAllByUserId(int userId)
        {
            try
            {
                var result = await _postsDal.GetAll(x => x.Post_IsActive && x.User_Id == userId);
                return new SuccessDataResult<List<Posts>>(result, Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Posts>>> GetPostsHomeScreen()
        {
            try
            {
                var result = await _postsDal.GetPostsHomeScreen();
                return new SuccessDataResult<List<Posts>>(result, Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }

        public async Task<IDataResult<Posts>> GetPostsDetailWithId(int postId)
        {
            try
            {
                var result = await _postsDal.GetPostsDetail(postId);
                return new SuccessDataResult<Posts>(result, Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<Posts>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Posts>>> GetFivePosts()
        {
            try
            {
                var resultOfPosts = await _postsDal.GetAll();
                var result = resultOfPosts.OrderByDescending(x => x.Post_CreatedDate).Take(5).ToList();
                return new SuccessDataResult<List<Posts>>(result, Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<Posts>>> GetPostWithPlateNo(string plateNo)
        {
            try
            {
                var result = await _postsDal.GetAll(x => x.Post_Plate == plateNo);
                return new SuccessDataResult<List<Posts>>(result.ToList(), Messages.PostGet);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }
    }
}
