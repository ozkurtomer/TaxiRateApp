using System.Collections.Generic;
using TaxiRateApp.Entities.Concrete;

namespace TaxiRateApp.Web.UI.ViewModels
{
    public class AddPostViewModel
    {
        public Posts Post { get; set; }
        public List<Cities> City { get; set; }
    }
}
