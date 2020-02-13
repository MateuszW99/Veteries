using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;

namespace Veteries.Pages.Admin.Customers
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Person CustomerObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            CustomerObj = new Person();
            if (id != null)
            {
                CustomerObj = _unitOfWork.Customer.GetFirstOrDefault(u => u.Id == id);
                if (CustomerObj == null)
                {
                    return Page();
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
            if (CustomerObj.Id == 0)
            {
                _unitOfWork.Customer.Add(CustomerObj);
            }
            else
            {
                _unitOfWork.Customer.Update(CustomerObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}