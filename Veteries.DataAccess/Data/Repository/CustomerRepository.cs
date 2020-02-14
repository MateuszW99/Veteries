using System.Linq;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository
{
    public class CustomerRepository : Repository<Person>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Person customer)
        {
            var objFromDb = _db.Person.FirstOrDefault(s => s.Id == customer.Id);

            objFromDb.FirstName = customer.FirstName;
            objFromDb.LastName = customer.LastName;
            objFromDb.PhoneNumber = customer.PhoneNumber;
            objFromDb.EmailAddress = customer.EmailAddress;

            _db.SaveChanges();
        }
    }
}
