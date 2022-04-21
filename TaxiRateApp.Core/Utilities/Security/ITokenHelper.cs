using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Core.Utilities.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Users users);
    }
}
