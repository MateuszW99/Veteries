using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Person Customer { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                Customer = _unitOfWork.Customer.GetFirstOrDefault(u => u.Id == id);
                if (Customer == null)
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
            if (Customer.Id == 0)
            {
                _unitOfWork.Customer.Add(Customer);
            }
            else
            {
                _unitOfWork.Customer.Update(Customer);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}