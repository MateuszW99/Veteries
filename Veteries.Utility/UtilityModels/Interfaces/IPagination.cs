namespace Veteries.Utility.UtilityModels.Interfaces
{
    public interface IPagination
    {
        int PageIndex { get; set; }
        int TotalPages { get; set; }
        const int PageSize = 5;
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
