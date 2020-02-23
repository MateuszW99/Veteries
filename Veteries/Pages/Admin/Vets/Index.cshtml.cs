using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;
using System.Linq;
using Veteries.Utility.UtilityModels;
using System;
using Microsoft.AspNetCore.Mvc;
using Veteries.Utility;

namespace Veteries.Pages.Admin.Vets
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<Veterinarian> Veterinarians { get; set; }
        public Pagination Pagination { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Pagination = new Pagination(10); // parameter is the max number of elements displayed on each page
        }

        public void OnGet(string sortOrder, int? pageNumber)
        {
            // Get the data from DB
            Veterinarians = _unitOfWork.Veterinarian.GetAll().ToList();

            // Sort the data
            ViewData["CurrentSort"] = sortOrder;
            ViewData["OfficeSort"] = String.IsNullOrEmpty(sortOrder) ? "office_desc" : "";
            ViewData["FNameSort"] = sortOrder == "FNameSort" ? "fName_desc" : "FNameSort";
            ViewData["LNameSort"] = sortOrder == "LNameSort" ? "lName_desc" : "LNameSort";
            ViewData["EmailSort"] = sortOrder == "EmailSort" ? "email_desc" : "EmailSort";
            ViewData["PhoneSort"] = sortOrder == "PhoneSort" ? "phone_desc" : "PhoneSort";
            Veterinarians = Veterinarians.SortVets(sortOrder);

            // Paginate the data
            Pagination.PageIndex = pageNumber ?? 1;
            Pagination.TotalPages = (int)Math.Ceiling(Veterinarians.Count() / (double)Pagination.PageSize);
            Veterinarians = Veterinarians.CreatePagination(Pagination.PageIndex, Pagination.PageSize);
        }

        // Only the address can be removed
        // since Veterinarian contains FK for an address
        public IActionResult OnGetDelete(int id)
        {
            var addressFromDb = _unitOfWork.Address.GetFirstOrDefault(s => s.Id == id);

            if (addressFromDb == null)
            {
                return new JsonResult(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Address.Remove(addressFromDb);
            _unitOfWork.Save();

            return new JsonResult(new { success = true, message = "Deleted succesfully." });
        }
    }
}