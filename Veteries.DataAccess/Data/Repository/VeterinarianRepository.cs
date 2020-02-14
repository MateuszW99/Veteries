using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository
{
    class VeterinarianRepository : Repository<Veterinarian>, IVeterinarianRepository
    {
        private readonly ApplicationDbContext _db;
        public VeterinarianRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Veterinarian veterinarian)
        {
            var objFromDb = _db.Veterinarian.FirstOrDefault(s => s.Id == veterinarian.Id);

            objFromDb.FirstName = veterinarian.FirstName;
            objFromDb.LastName = veterinarian.LastName;
            objFromDb.OfficeName = veterinarian.OfficeName;
            objFromDb.PaymentRange = veterinarian.PaymentRange;
            objFromDb.PhoneNumber = veterinarian.PhoneNumber;
            objFromDb.EmailAddress = veterinarian.EmailAddress;

            _db.SaveChanges();
        }
    }
}
