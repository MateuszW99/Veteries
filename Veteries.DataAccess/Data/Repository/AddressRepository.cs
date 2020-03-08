﻿using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Veteries.DataAccess.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _db;

        public AddressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCityListForDropdown()
        {
            return null;
        }

        public void Update(Address address)
        {
            var objFromDb = _db.Address.FirstOrDefault(s => s.Id == address.Id);

            objFromDb.City = address.City;
            objFromDb.Street = address.Street;
            objFromDb.ZipCode = address.ZipCode;

            _db.SaveChanges();
        }
    }
}
