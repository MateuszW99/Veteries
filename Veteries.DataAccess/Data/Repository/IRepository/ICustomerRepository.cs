using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Person>
    {
        void Update(Person customer);
    }
}
