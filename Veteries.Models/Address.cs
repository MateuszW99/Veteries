using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veteries.Utility.UtilityModels.Interfaces;

namespace Veteries.Models
{
    public class Address : IAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[A-Z][a-z]+")]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required, Display(Name = "Zip code")]
        [RegularExpression(@"\d{2}-?\d{3,4}")]
        public string ZipCode { get; set; }
    }
}
