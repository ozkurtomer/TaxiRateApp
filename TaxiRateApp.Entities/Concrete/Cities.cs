using System;
using System.Collections.Generic;
using TaxiRateApp.Core.Entities;

namespace TaxiRateApp.Entities.Concrete
{
    public partial class Cities : IEntity
    {
        public Cities()
        {
            Posts = new HashSet<Posts>();
        }

        public int City_Id { get; set; }
        public string City_Name { get; set; }
        public bool Is_Active { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
