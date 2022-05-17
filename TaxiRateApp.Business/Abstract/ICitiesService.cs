using System.Threading.Tasks;
using System.Collections.Generic;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Core.Utilities.Results.Abstract;

namespace TaxiRateApp.Business.Abstract
{
    public interface ICitiesService
    {
        Task<IDataResult<List<Cities>>> GetAll();
        Task<IDataResult<Cities>> GetById(int cityId);
        Task<IDataResult<Cities>> GetByName(string cityName);

        Task<IResult> Add(Cities cities);
        Task<IResult> Update(Cities cities);
        Task<IResult> Delete(Cities cities);
    }
}
