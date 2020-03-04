using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface IVeterinarianRepository : IRepository<Veterinarian>
    {
        public void Update(Veterinarian veterinarian);

        IEnumerable<SelectListItem> GetVetListForDropdown();
    }
}
