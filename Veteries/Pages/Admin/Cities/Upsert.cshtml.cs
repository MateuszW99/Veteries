using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;

namespace Veteries.Pages.Admin.Cities
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public City CityObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            CityObj = new City();
            if (id != null)
            {
                CityObj = _unitOfWork.City.GetFirstOrDefault(s => s.ID == id);
                if (CityObj == null)
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

            if (CityObj.ID == 0)
            {
                _unitOfWork.City.Add(CityObj);
            }
            else
            {
                _unitOfWork.City.Update(CityObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}