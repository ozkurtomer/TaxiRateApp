using RestSharp;
using RestSharp.Authenticators;
using TaxiRateApp.Web.Constants;

namespace TaxiRateApp.Web.Utilities.ClientUtilities
{
    public static class CreateClient
    {
        public static RestClient GetClient(string url, bool isToken = true)
        {
            RestClient client = new RestClient($"{Constant.ApiUrl}{url}");
            if (isToken)
            {
                var authToken = new JwtAuthenticator(Constant.ApiToken);
                client.Authenticator = authToken;
            }
            return client;
        }
    }
}
