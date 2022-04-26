using System;

namespace TaxiRateApp.Core.Utilities.Security
{
    public class AccessToken
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
