using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;
using System.Linq;
using Veteries.Utility.UtilityModels;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Veteries.Pages.Admin.Vets
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<Veterinarian> Veterinarians { get; set; }

        // Sorting variables
        public string OfficeSort { get; set; }
        public string FNameSort { get; set; }
        public string LNameSort { get; set; }
        public string EmailSort { get; set; }
        public string PhoneSort { get; set; }

        // Pagination Variables
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        private const int PageSize = 5;
        public bool HasPreviousPage {  get => PageIndex > 1; }
        public bool HasNextPage { get => PageIndex < TotalPages; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

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
            Veterinarians = SortTable.SortVets(sortOrder, Veterinarians);

            // Paginate the data
            PageIndex = pageNumber ?? 1;
            TotalPages = (int)Math.Ceiling(Veterinarians.Count() / (double)PageSize);
            Veterinarians = Veterinarians.CreatePagination(PageIndex, PageSize);
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