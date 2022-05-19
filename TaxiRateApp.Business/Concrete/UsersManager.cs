using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Business.Constants;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Core.Utilities.Results.Concrete;

namespace TaxiRateApp.Business.Concrete
{
    public class UsersManager : IUsersService
    {
        public IUsersDal _usersDal;
        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public async Task<IResult> Add(Users users)
        {
            try
            {
                await _usersDal.Add(users);
                return new SuccessResult(Messages.UserAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
        public async Task<IResult> Update(Users users)
        {
            try
            {
                await _usersDal.Update(users);
                return new SuccessResult(Messages.UserUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> Delete(Users users)
        {
            try
            {
                await _usersDal.Delete(users);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IDataResult<List<Users>>> GetAll()
        {
            try
            {
                var result = await _usersDal.GetAll();
                return new SuccessDataResult<List<Users>>(result, Messages.UserGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<Users>>(ex.Message);
            }
        }

        public async Task<IDataResult<Users>> GetByName(string userName)
        {
            try
            {
                var result = await _usersDal.Get(x => x.User_Email == userName);
                return new SuccessDataResult<Users>(result, Messages.UserGet);
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<Users>(ex.Message);
            }
        }
    }
}
