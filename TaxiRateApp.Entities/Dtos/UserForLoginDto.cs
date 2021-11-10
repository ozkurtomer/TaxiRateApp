using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.Entities;

namespace TaxiRateApp.Entities.Dtos
{
    public class UserForLoginDto : IDTO
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
