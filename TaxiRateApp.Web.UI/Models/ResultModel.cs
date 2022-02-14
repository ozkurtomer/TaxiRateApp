namespace TaxiRateApp.Web.UI.Models
{
    public class ResultModel<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
