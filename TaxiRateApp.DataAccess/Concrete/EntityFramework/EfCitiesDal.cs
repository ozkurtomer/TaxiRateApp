﻿using TaxiRateApp.Entities.Concrete;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.Core.DataAccess.EntityFramework;
using TaxiRateApp.DataAccess.Concrete.EntityFramework.Context;

namespace TaxiRateApp.DataAccess.Concrete.EntityFramework
{
    public class EfCitiesDal : EfEntityRepositoryBase<Cities, TaxiRateAppContext>, ICitiesDal
    {
    }
}
