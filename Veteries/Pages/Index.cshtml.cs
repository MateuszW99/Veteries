using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models.ViewModels;

namespace Veteries.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public LandingPageDropdownVM DropdownListModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            DropdownListModel = new LandingPageDropdownVM
            {
                CityList = _unitOfWork.Address.GetCityListForDropdown(),
                SpeciesList = _unitOfWork.Species.GetSpeciesListForDropdown()
            };
            return Page();
        }
    }
}
