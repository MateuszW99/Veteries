using System.ComponentModel.DataAnnotations;

namespace Veteries.Models.ViewModels
{
    public class MainSearchVM
    {
        [Required]
        public int CityID { get; set; }

        [Required]
        public int SpeciesID { get; set; }
    }
}
