using System.ComponentModel.DataAnnotations;
using Veteries.Models.Interfaces;

namespace Veteries.Models
{
    public class City : ICity
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"[A-Z][a-z]+")]
        public string Name { get; set; }
    }
}
