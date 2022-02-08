using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace TaxiRateApp.Web.UI.Constants
{
    public static class Client
    {
        public static RestClient ClientCreate(string url, bool isToken = true)
        {
            RestClient client = new RestClient($"{Constant.ApiUrl}{url}");
            if (isToken)
            {
                var authToken = new JwtAuthenticator(Constant.ApiToken);
                client.Authenticator = authToken;
            }
            return client;
        }

        public static RestRequest CreateRequest(Method method, object parameters = null)
        {
            var request = new RestRequest();
            request.Method = method;
            request.AddHeader("content-type", "application/json");
            if (parameters != null)
                request.AddParameter("application/json", JsonConvert.SerializeObject(parameters), ParameterType.RequestBody);

            return request;
        }
    }
}
