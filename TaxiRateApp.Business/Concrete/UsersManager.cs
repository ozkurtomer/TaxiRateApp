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
    public class UsersManager : IUsersService
    {
        public IUsersDal _usersDal;
        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IResult Add(Users users)
        {
            try
            {
                _usersDal.Add(users);
                return new SuccessResult(Messages.UserAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
        public IResult Update(Users users)
        {
            try
            {
                _usersDal.Update(users);
                return new SuccessResult(Messages.UserUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(Users users)
        {
            try
            {
                _usersDal.Delete(users);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<Users>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Users>>(_usersDal.GetAll(), Messages.UserGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Users>>(ex.Message);
            }
        }

        public IDataResult<Users> GetByName(string userName)
        {
            try
            {
                return new SuccessDataResult<Users>(_usersDal.Get(x=>x.User_UserName == userName), Messages.UserGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<Users>(ex.Message);
            }
        }
    }
}
