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

        public IResult Add(Posts posts)
        {
            try
            {
                _postsDal.Add(posts);
                return new SuccessResult(Messages.PostAdded);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Update(Posts posts)
        {
            try
            {
                _postsDal.Update(posts);
                return new SuccessResult(Messages.PostUpdated);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(Posts posts)
        {
            try
            {
                _postsDal.Delete(posts);
                return new SuccessResult(Messages.PostDeleted);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<Posts>> GetAll()
        {
            try
            {
                var result = _postsDal.GetAll(x => x.Post_IsActive).Select(x => new Posts
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
                }).ToList();
                return new SuccessDataResult<List<Posts>>(result, Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }

        public IDataResult<List<Posts>> GetAllByUserId(int userId)
        {
            try
            {
                return new SuccessDataResult<List<Posts>>(_postsDal.GetAll(x => x.Post_IsActive && x.User_Id == userId), Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }

        public IDataResult<List<Posts>> GetPostsHomeScreen()
        {
            try
            {
                var result = _postsDal.GetPostsHomeScreen();
                return new SuccessDataResult<List<Posts>>(result, Messages.PostGet, result.Count, 100);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }

        public IDataResult<Posts> GetPostsDetailWithId(int postId)
        {
            try
            {
                return new SuccessDataResult<Posts>(_postsDal.Get(x => x.Post_Id == postId), Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<Posts>(ex.Message);
            }
        }

        public IDataResult<List<Posts>> GetFivePosts()
        {
            try
            {
                var result = _postsDal.GetAll().OrderByDescending(x => x.Post_CreatedDate).Take(5).ToList();
                return new SuccessDataResult<List<Posts>>(result, Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }
    }
}
