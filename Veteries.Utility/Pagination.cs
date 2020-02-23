using Veteries.Utility.UtilityModels.Interfaces;

namespace Veteries.Utility
{
    public class Pagination : IPagination
    {
        public Pagination(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public readonly int PageSize;
        public bool HasPreviousPage { get => PageIndex > 1; }
        public bool HasNextPage { get => PageIndex < TotalPages; }
    }
}
