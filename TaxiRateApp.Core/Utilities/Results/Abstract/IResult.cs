
namespace TaxiRateApp.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        int TotalItemsCount { get; }
        int ItemPerPage { get; }
    }
}
