using Veteries.DataAccess.Data.Repository;
using Veteries.DataAccess.Data.Repository.IRepository;

namespace Veteries.DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Species = new SpeciesRepository(_db);
            Patient = new PatientRepository(_db);
            Customer = new CustomerRepository(_db);
            Address = new AddressRepository(_db);
            Veterinarian = new VeterinarianRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }

        public ISpeciesRepository Species { get; private set; }
        public IPatientRepository Patient { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IAddressRepository Address { get; private set; }
        public IVeterinarianRepository Veterinarian { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
