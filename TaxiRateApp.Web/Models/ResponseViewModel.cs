namespace TaxiRateApp.Web.Models
{
    public class ResponseViewModel<T>
    {
        public T data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}
