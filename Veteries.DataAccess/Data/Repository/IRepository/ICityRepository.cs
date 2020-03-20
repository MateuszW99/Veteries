﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface ICityRepository : IRepository<City>
    {
        void Update(City city);

        IEnumerable<SelectListItem> GetCityListForDropdown();
    }
}