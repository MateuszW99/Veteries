using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;
using System.Linq;
using Veteries.Utility.UtilityModels;
using System;

namespace Veteries.Pages.Admin.Vets
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<Veterinarian> Veterinarians { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string OfficeSort { get; set; }
        public string FNameSort { get; set; }
        public string LNameSort { get; set; }
        public string EmailSort { get; set; }
        public string PhoneSort { get; set; }

        public void OnGet(string sortOrder)
        {
            Veterinarians = _unitOfWork.Veterinarian.GetAll().ToList();


            OfficeSort = String.IsNullOrEmpty(sortOrder) ? "office_desc" : "";
            FNameSort = sortOrder == "FNameSort" ? "fName_desc" : "FNameSort";
            LNameSort = sortOrder == "LNameSort" ? "lName_desc" : "LNameSort";
            EmailSort = sortOrder == "EmailSort" ? "email_desc" : "EmailSort";
            PhoneSort = sortOrder == "PhoneSort" ? "phone_desc" : "PhoneSort";

            Veterinarians = SortTable.SortVets(sortOrder, Veterinarians);


        }
    }
}