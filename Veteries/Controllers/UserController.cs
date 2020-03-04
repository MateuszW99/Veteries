using System;
using Microsoft.AspNetCore.Mvc;
using Veteries.DataAccess.Data.Repository.IRepository;

namespace Veteries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            return Json(new { data = _unitOfWork.ApplicationUser.GetAll()});
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.Id == id);
            if (objFromDb == null)
            {
                var alertMessage = objFromDb.LockoutEnd > DateTime.Now ? "Error while unlocking." : "Error while locking.";
                return Json(new { success = false, message = alertMessage });
            }
            
            _unitOfWork.ApplicationUser.LockUnlock(objFromDb);
            _unitOfWork.Save();
            var mes = objFromDb.LockoutEnd <= DateTime.Now ? "Locking" : "Unlocking";
            return Json(new { success = true, message = $"{mes} successful."});
        }
    }
}