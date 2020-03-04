using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veteries.Models.Interfaces;

namespace Veteries.Models
{
    public class Veterinarian : IVeterinarian
    {
        // Personal data variables
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "First name")]
        [StringLength(15, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last name")]
        [StringLength(15, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required, Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress, Display(Name ="Email address")]
        public string EmailAddress { get; set; }

        [Required, Display(Name = "Office name")]
        [StringLength(20, MinimumLength = 2)]
        public string OfficeName { get; set; }

        [Required, Display(Name = "Payment range")]
        [RegularExpression(@"\d{2,4}-\d{2,4}")]
        public string PaymentRange { get; set; }

        // Address variables
        [Display(Name = "Address")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
