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
                return new SuccessDataResult<List<Posts>>(_postsDal.GetAll(x=>x.Post_IsActive),Messages.PostGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Posts>>(ex.Message);
            }
        }
    }
}
