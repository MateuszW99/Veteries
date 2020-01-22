using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Veteries.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\d*")]
        public int Age { get; set; }


        [Display(Name = "Owner")]
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Person Owner { get; set; }


        [Display(Name = "Species")]
        public int SpeciesId { get; set; }

        [ForeignKey("SpeciesId")]
        public virtual Species Species { get; set; }
    }
}
