using TaxiRateApp.Entities.Abstract;

namespace TaxiRateApp.Entities.Dtos
{
    public class UserForLoginDto : IDTO
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
