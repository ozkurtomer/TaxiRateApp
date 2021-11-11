using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.Entities.Concrete;

namespace TaxiRateApp.Core.Utilities.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Users users);
    }
}
