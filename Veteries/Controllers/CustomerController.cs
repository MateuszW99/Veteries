using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veteries.DataAccess.Data;

namespace Veteries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult OnGet()
        {
            return Json(new { data = _unitOfWork.Customer.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Customer.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting."});
            }
            _unitOfWork.Customer.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, messsage = "Deleted successfully." });
        }
    }
}