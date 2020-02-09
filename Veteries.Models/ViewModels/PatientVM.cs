using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Veteries.Models.ViewModels
{
    public class PatientVM
    {
        public Patient Patient { get; set; }
        public IEnumerable<SelectListItem> SpeciesList { get; set; }
    }
}
