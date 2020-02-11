using System;
using System.Collections.Generic;
using System.Text;

namespace Veteries.Models.Interfaces
{
    public interface IVeterinarian
    {
        public string OfficeName { get; set; }
        public string Address { get; set; }
        //public string WorkingHours { get; set; }
        // TODO: add Schedule prop
        public string PaymentRange { get; set; }
    }
}
