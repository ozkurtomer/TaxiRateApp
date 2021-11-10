using System;
using System.Collections.Generic;
using TaxiRateApp.Core.Entities;

namespace TaxiRateApp.Entities.Concrete
{
    public partial class Users : IEntity
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
        }

        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_UserName { get; set; }
        public string User_PasswordHash { get; set; }
        public string User_PasswordSalt { get; set; }
        public string User_Ip { get; set; }
        public bool User_Anonymous { get; set; }
        public DateTime User_CreatedDate { get; set; }
        public bool User_IsActive { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
