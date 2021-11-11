using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Core.Entities;

namespace TaxiRateApp.Entities.Dtos
{
    public class UserForRegisterDto : IDTO
    {
        public string UserName { get; set; }
        public string UserUserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public bool   UserAnonymous { get; set; }
    }
}
