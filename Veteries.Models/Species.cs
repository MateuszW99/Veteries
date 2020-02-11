using System.ComponentModel.DataAnnotations;
using Veteries.Models.Interfaces;

namespace Veteries.Models
{
    public class Species : ISpecies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"[A-Z][a-z]+", ErrorMessage = "The Name should start with an upper-case letter and mustn't contain anything besides letters")]
        public string Name { get; set; }
    }
}
