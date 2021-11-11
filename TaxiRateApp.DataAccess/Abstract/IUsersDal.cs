﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.DataAccess;
using TaxiRateApp.Core.Entities.Concrete;

namespace TaxiRateApp.DataAccess.Abstract
{
    public interface IUsersDal : IEntityRepository<Users>
    {
    }
}
