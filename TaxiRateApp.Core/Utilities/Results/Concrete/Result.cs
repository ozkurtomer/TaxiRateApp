using TaxiRateApp.Core.Utilities.Results.Abstract;

namespace TaxiRateApp.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool success, string message, int totalItemCount, int itemPerPage) : this(success)
        {
            Message = message;
            TotalItemsCount = totalItemCount;
            ItemPerPage = itemPerPage;
        }

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }

        public int TotalItemsCount { get; }

        public int ItemPerPage { get; }
    }
}
