using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Veteries.DataAccess;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;
using Veteries.Utility.Helper;

namespace Veteries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            if ( _userManager != null)
            {
                Console.WriteLine("ok");
            }
        }

        [HttpGet]
        public IActionResult OnGet()
        {
            //return Json(new { data = _unitOfWork.Customer.GetAll() });
            return Json(new { data = _userManager.GetUsersInRoleAsync(StaticDetails.CustomerRole).Result.ToList()});
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