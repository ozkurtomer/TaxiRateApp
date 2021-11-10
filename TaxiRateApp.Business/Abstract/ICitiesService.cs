using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Entities.Concrete;

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
