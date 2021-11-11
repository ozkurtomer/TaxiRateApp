using System;
using TaxiRateApp.Core.Entities;
using TaxiRateApp.Core.Entities.Concrete;

namespace TaxiRateApp.Entities.Concrete
{
    public partial class Posts : IEntity
    {
        public int Post_Id { get; set; }
        public int User_Id { get; set; }
        public int City_Id { get; set; }
        public string Post_Plate { get; set; }
        public string Post_Description { get; set; }
        public int? Post_Stars { get; set; }
        public DateTime Post_CreatedDate { get; set; }
        public bool Post_IsActive { get; set; }

        public virtual Cities City { get; set; }
        public virtual Users User { get; set; }
    }
}
