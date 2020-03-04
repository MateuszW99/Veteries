using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Veteries.Models.ViewModels
{
    public class LandingPageDropdownVM
    {
        public int CityID { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }

        public int SpeciesID { get; set; }
        public IEnumerable<SelectListItem> SpeciesList { get; set; }

    }
}
