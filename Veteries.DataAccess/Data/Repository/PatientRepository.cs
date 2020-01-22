using System.Linq;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Patient patient)
        {
            var objFromDb = _db.Patient.FirstOrDefault(s => s.Id == patient.Id);

            objFromDb.Name = patient.Name;
            objFromDb.Age = patient.Age;
            objFromDb.SpeciesId = patient.SpeciesId;
            objFromDb.OwnerId = patient.OwnerId;

            _db.SaveChanges();
        }

    }
}
