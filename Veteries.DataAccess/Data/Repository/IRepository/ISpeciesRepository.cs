using System.Collections.Generic;
using System.Web.Mvc;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface ISpeciesRepository : IRepository<Species>
    {
        IEnumerable<SelectListItem> GetSpeciesListForDropDown();

        void Update(Species species);
    }
}
