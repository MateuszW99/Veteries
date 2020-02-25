using System.ComponentModel.DataAnnotations;

namespace Veteries.Utility.Helper
{
    public class StaticDetails
    {
        public const int MaxPageSize = 10;

        [Display(Name = "Admin")]
        public const string AdminRole = "Admin";

        [Display(Name = "Maintenance")]
        public const string MaintenanceRole = "Maintenance";

        [Display(Name = "Office Owner")]
        public const string OfficeOwnerRole = "OfficeOwner";


        public const string CustomerRole = "Customer";
    }
}
