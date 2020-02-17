using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Veteries.Pages.Admin.Vets
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<Veterinarian> Veterinarians { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet()
        {
            Veterinarians = (List<Veterinarian>)_unitOfWork.Veterinarian.GetAll();

        }
    }
}