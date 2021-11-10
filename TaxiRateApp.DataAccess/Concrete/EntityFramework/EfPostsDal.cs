﻿using TaxiRateApp.Core.DataAccess.EntityFramework;
using TaxiRateApp.DataAccess.Abstract;
using TaxiRateApp.DataAccess.Concrete.EntityFramework.Context;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Concrete.EntityFramework
{
    public class EfPostsDal : EfEntityRepositoryBase<Posts, TaxiRateAppContext>, IPostsDal
    {
    }
}
