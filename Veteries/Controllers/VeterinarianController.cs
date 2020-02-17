using Microsoft.AspNetCore.Mvc;
using Veteries.DataAccess.Data.Repository.IRepository;

namespace Veteries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarianController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VeterinarianController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult OnGet()
        {
            return Json(new { data = _unitOfWork.Veterinarian.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult OnDelete(int id)
        {
            var objFromDb = _unitOfWork.Veterinarian.GetFirstOrDefault(s => s.Id == id);

            if (objFromDb == null)
            {
                return Json(new { successs = false, message = "Error while deleting." });
            }

            _unitOfWork.Veterinarian.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully." } );
        }
    }
}