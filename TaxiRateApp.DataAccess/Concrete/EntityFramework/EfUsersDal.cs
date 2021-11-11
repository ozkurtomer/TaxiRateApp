using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.DataAccess.EntityFramework;
using TaxiRateApp.Core.Entities.Concrete;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.DataAccess.Concrete.EntityFramework.Context;

namespace TaxiRateApp.DataAccess.Concrete.EntityFramework
{
    public class EfUsersDal : EfEntityRepositoryBase<Users, TaxiRateAppContext>, IUsersDal
    {
    }
}
