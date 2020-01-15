using System.ComponentModel.DataAnnotations;

namespace Veteries.Models
{
    public class Species
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
