using System.ComponentModel.DataAnnotations;
using Veteries.Models.Interfaces;

namespace Veteries.Models
{
    public class Person : IPerson
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, MinLength(2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required, Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }

        public string FullName()
        {
            return @"{FirstName} {LastName}";
        }
    }
}
