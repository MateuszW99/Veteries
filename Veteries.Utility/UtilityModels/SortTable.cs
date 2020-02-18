using System.Collections.Generic;
using System.Linq;
using Veteries.Models;
using Veteries.Utility.UtilityModels.Interfaces;

namespace Veteries.Utility.UtilityModels
{
    public static class SortTable
    {
        public static List<Veterinarian> SortVets(string sortOrder, List<Veterinarian> veterinarians)
        {
            switch (sortOrder)
            {
                case "office_desc":
                    {
                        veterinarians = veterinarians.OrderByDescending(s => s.OfficeName).ToList();
                        break;
                    }

                case "FNameSort":
                    {
                        veterinarians = veterinarians.OrderBy(s => s.FirstName).ToList();
                        break;
                    }

                case "fName_desc":
                    {
                        veterinarians = veterinarians.OrderByDescending(s => s.FirstName).ToList();
                        break;
                    }

                case "LNameSort":
                    {
                        veterinarians = veterinarians.OrderBy(s => s.LastName).ToList();
                        break;
                    }

                case "lName_desc":
                    {
                        veterinarians = veterinarians.OrderByDescending(s => s.LastName).ToList();
                        break;
                    }

                case "EmailSort":
                    {
                        veterinarians = veterinarians.OrderBy(s => s.EmailAddress).ToList();
                        break;
                    }

                case "email_desc":
                    {
                        veterinarians = veterinarians.OrderByDescending(s => s.EmailAddress).ToList();
                        break;
                    }

                case "PhoneSort":
                    {
                        veterinarians = veterinarians.OrderBy(s => s.PhoneNumber).ToList();
                        break;
                    }

                case "phone_desc":
                    {
                        veterinarians = veterinarians.OrderByDescending(s => s.PhoneNumber).ToList();
                        break;
                    }
            }
            return veterinarians.ToList();
        }
    }
}
