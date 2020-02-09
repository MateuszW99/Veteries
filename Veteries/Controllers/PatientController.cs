using Microsoft.AspNetCore.Mvc;
using Veteries.DataAccess.Data.Repository.IRepository;

namespace Veteries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Patient.GetAll(null, null, "Species") });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Patient.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json (new {success = false, message = "Error while deleting."});
            }
            _unitOfWork.Patient.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted successfully." });
        }

    }
}