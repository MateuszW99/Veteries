using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Veteries.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        // TODO: 
        // add a pet or a list<pet>

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\d{2,4}[x-\s]?\d{2,4}[x-\s]?d{3,4}")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+@[a-z]+\.[a-z]{1,3}")]
        public string EmailAddress { get; set; }
    }
}
