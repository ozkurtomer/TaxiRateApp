using System.Collections.Generic;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Business.Abstract
{
    public interface IUsersService
    {
        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetByName(string userName);

        IResult Add(Users users);
        IResult Update(Users users);
        IResult Delete(Users users);
    }
}
