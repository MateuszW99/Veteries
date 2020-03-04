using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface IAddressRepository : IRepository<Address>
    {
        void Update(Address address);

        IEnumerable<SelectListItem> GetCityListForDropdown();
    }
}
