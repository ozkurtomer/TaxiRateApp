using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.Entities.Concrete;
using TaxiRateApp.Core.Utilities.Results.Abstract;

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
