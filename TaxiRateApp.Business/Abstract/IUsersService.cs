using System.Threading.Tasks;
using System.Collections.Generic;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Core.Utilities.Results.Abstract;

namespace TaxiRateApp.Business.Abstract
{
    public interface IUsersService
    {
        Task<IDataResult<List<Users>>> GetAll();
        Task<IDataResult<Users>> GetByUserId(int userId);
        Task<IDataResult<Users>> GetByName(string userName);
        
        Task<IResult> Add(Users users);
        Task<IResult> Update(Users users);
        Task<IResult> Delete(Users users);
    }
}
