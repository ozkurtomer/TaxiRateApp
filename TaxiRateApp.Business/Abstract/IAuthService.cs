using System.Threading.Tasks;
using TaxiRateApp.Entities.Dtos;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Core.Utilities.Results.Abstract;

namespace TaxiRateApp.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<Users>> Register(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<Users>> Login(UserForLoginDto userForLoginDto);
        Task<IDataResult<AccessToken>> CreateAccessToken(Users users);
    }
}
