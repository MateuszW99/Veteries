using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veteries.DataAccess.Data.Repository.IRepository;

namespace Veteries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpeciesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Species.GetAll() });
        }
    }
}