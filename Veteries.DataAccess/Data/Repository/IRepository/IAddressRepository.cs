using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface IAddressRepository : IRepository<Address>
    {
        void Update(Address address);
    }
}
