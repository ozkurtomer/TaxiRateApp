using TaxiRateApp.Entities.Dtos;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Core.Utilities.Results.Abstract;

namespace TaxiRateApp.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Users> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(Users users);
    }
}
