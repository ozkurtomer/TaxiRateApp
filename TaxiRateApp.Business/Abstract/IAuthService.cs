using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Core.Utilities.Security;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Entities.Dtos;

namespace TaxiRateApp.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Users> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(Users users);
    }
}
