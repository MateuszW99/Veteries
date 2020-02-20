using System;
using System.Collections.Generic;
using System.Linq;

namespace Veteries.Utility.UtilityModels
{
    public static class PaginatedList
    {
       public static List<T> CreatePagination<T>(this List<T> source, int pageIndex, int pageSize)
       {
            return source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
       }
    }
}
