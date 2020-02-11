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
    }
}