using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;
using Veteries.Models.ViewModels;

namespace Veteries.Pages.Admin.Patients
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public PatientVM PatientObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            PatientObj = new PatientVM
            {
                Patient = new Patient(),
                SpeciesList = _unitOfWork.Species.GetSpeciesListForDropdown()
            };
            if (id != null)
            {
                PatientObj.Patient = _unitOfWork.Patient.GetFirstOrDefault(s => s.Id == id);
                if (PatientObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (PatientObj.Patient.Id == 0)
            {
                _unitOfWork.Patient.Add(PatientObj.Patient);
            }
            else
            {
                _unitOfWork.Patient.Update(PatientObj.Patient);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}