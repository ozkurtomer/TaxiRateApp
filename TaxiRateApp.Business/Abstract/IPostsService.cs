using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.Utilities.Results.Abstract;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Business.Abstract
{
    public interface IPostsService
    {
        IDataResult<List<Posts>> GetAll();

        IResult Add(Posts posts);
        IResult Update(Posts posts);
        IResult Delete(Posts posts);
    }
}
