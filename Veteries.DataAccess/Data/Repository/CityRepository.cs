using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(City city)
        {
            var objFromDb = _db.City.FirstOrDefault(s => s.ID == city.ID);
            objFromDb.Name = city.Name;
            _db.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetCityListForDropdown()
        {
            return _db.City.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.ID.ToString()
            }).Distinct();
        }


    }
}
