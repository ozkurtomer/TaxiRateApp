using TaxiRateApp.Core.DataAccess;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Abstract
{
    public interface IUsersDal : IEntityRepository<Users>
    {
    }
}
