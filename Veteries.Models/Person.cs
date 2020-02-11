using System.ComponentModel.DataAnnotations;
using Veteries.Models.Interfaces;

namespace Veteries.Models
{
    public class Person : IPerson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
