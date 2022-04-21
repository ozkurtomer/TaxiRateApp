using System;

namespace TaxiRateApp.Core.Utilities.Security
{
    public class AccessToken
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
