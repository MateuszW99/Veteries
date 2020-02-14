using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veteries.Models.Interfaces;

namespace Veteries.Models
{
    public class Veterinarian : IVeterinarian
    {
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string OfficeName { get; set; }

        [Required]
        [RegularExpression(@"\d{2,4}-\d{2,4}")]
        public string PaymentRange { get; set; }

        [Display(Name = "Address")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }
}
