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
        public string PhoneNumber { get; set; }

        [Required]
        public string EailAddress { get; set; }
    }
}
