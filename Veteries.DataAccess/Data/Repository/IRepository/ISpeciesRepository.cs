using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface ISpeciesRepository : IRepository<Species>
    {
        IEnumerable<SelectListItem> GetSpeciesListForDropDown();

        void Update(Species species);
    }
}
