using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }
    }
}
