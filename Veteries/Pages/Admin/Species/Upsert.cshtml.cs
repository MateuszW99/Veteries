using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veteries.DataAccess.Data.Repository.IRepository;

namespace Veteries.Pages.Admin.Species
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Species SpeciesObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            SpeciesObj = new Models.Species();
            if (id != null)
            {
                SpeciesObj = _unitOfWork.Species.GetFirstOrDefault(u => u.Id == id);
                if (SpeciesObj == null)
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
            if (SpeciesObj.Id == 0)
            {
                _unitOfWork.Species.Add(SpeciesObj);
            }
            else
            {
                _unitOfWork.Species.Update(SpeciesObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}