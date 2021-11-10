using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Business.Abstract;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Entities.Dtos;

namespace TaxiRateApp.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        public IDataResult<Users> Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Users> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            throw new NotImplementedException();
        }
    }
}
