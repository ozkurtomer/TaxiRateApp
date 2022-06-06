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
    public class CommentsManager : ICommentsService
    {
        ICommentsDal _contentsDal;
        public CommentsManager(ICommentsDal contentsDal)
        {
            _contentsDal = contentsDal;
        }

        public IResult Add(Comments contents)
        {
            try
            {
                _contentsDal.Add(contents);
                return new SuccessResult(Messages.CommentAdded);
            }

            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Update(Comments contents)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Comments contents)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Comments>> GetAllByPostsId(int postId)
        {
            return new SuccessDataResult<List<Comments>>(_contentsDal.GetContentsWithDetail(x=>x.Post_Id == postId));
        }

        public IDataResult<Comments> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
