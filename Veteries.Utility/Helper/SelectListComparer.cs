using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Veteries.Utility.Helper
{
    public class SelectListComparer : IEqualityComparer<SelectListItem>
    {
        public bool Equals(SelectListItem x, SelectListItem y)
        {
            return x.Text == y.Text && x.Value == y.Value;
        }

        public int GetHashCode(SelectListItem obj)
        {
            int hashText = obj.Text == null ? 0 : obj.Text.GetHashCode();
            int hashValue = obj.Value == null ? 0 : obj.Value.GetHashCode();
            return hashText ^ hashValue;
        }
    }
}
