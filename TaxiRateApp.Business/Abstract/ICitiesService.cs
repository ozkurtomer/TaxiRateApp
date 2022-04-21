using System.Collections.Generic;
using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.Core.Utilities.Results.Abstract;

namespace TaxiRateApp.Business.Abstract
{
    public interface ICitiesService
    {
        IDataResult<List<Cities>> GetAll();
        IDataResult<Cities> GetById(int cityId);
        IDataResult<Cities> GetByName(string cityName);

        IResult Add(Cities cities);
        IResult Update(Cities cities);
        IResult Delete(Cities cities);
    }
}
