using System;
using TaxiRateApp.Entities.Abstract;

namespace TaxiRateApp.Entities.Concrete
{
    public partial class Comments : IEntity
    {
        public int Comment_Id { get; set; }
        public int Post_Id { get; set; }
        public int User_Id { get; set; }
        public string Comment_Description { get; set; }
        public DateTime Comment_CreatedDate { get; set; }
        public bool Comment_IsActive { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
    }
}
