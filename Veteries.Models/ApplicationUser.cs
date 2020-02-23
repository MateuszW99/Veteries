using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veteries.Models.Interfaces;

namespace Veteries.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        [Display(Name = "Full name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
