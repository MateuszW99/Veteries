using System;
using System.Linq;
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

        [BindProperty]
        public Models.Address AddressObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            VeterinarianObj = new Models.Veterinarian();
            if (id != null)
            {
                AddressObj = _unitOfWork.Address.GetFirstOrDefault(u => u.Id == id);
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
                string messages = String.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors)
                                                           .Select(v => v.ErrorMessage + " " + v.Exception));
                return Page();
            }
            if (VeterinarianObj.Id == 0 && AddressObj.Id == 0)
            {
                _unitOfWork.Address.Add(AddressObj);
                _unitOfWork.Save();
                VeterinarianObj.AddressId = AddressObj.Id;
                _unitOfWork.Veterinarian.Add(VeterinarianObj);
            }
            else
            {
                _unitOfWork.Address.Update(AddressObj);
                _unitOfWork.Save();
                VeterinarianObj.AddressId = AddressObj.Id;
                _unitOfWork.Veterinarian.Update(VeterinarianObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }


    }
}