using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;

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
        public Patient PatientObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            PatientObj = new Patient();
            if (id != null)
            {
                PatientObj = _unitOfWork.Patient.GetFirstOrDefault(s => s.Id == id);
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
            if (PatientObj.Id == 0)
            {
                _unitOfWork.Patient.Add(PatientObj);
            }
            else
            {
                _unitOfWork.Patient.Update(PatientObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("/Index");
        }
    }
}