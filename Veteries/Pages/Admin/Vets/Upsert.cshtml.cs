using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veteries.DataAccess.Data.Repository.IRepository;

namespace Veteries.Pages.Admin.Vets
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Veterinarian VeterinarianObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            VeterinarianObj = new Models.Veterinarian();
            if (id != null)
            {
                VeterinarianObj = _unitOfWork.Veterinarian.GetFirstOrDefault(u => u.Id == id);
            }
            if (VeterinarianObj == null)
            {
                return Page();
            }
            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (VeterinarianObj.Id == 0)
            {
                _unitOfWork.Veterinarian.Add(VeterinarianObj);
            }
            else
            {
                _unitOfWork.Veterinarian.Update(VeterinarianObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}