using System.Threading.Tasks;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Core.Utilities.Security
{
    public interface ITokenHelper
    {
        Task<AccessToken> CreateToken(Users users);
    }
}
