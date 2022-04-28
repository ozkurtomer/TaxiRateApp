using TaxiRateApp.Entities.Abstract;

namespace TaxiRateApp.Entities.Dtos
{
    public class UserForRegisterDto : IDTO
    {
        public string UserName { get; set; }
        public string UserUserName { get; set; }
        public string UserPassword { get; set; }
        public string UserRePassword { get; set; }
        public string UserEmail { get; set; }
        public string UserIpAddress { get; set; }
        public bool   UserAnonymous { get; set; }
    }
}
