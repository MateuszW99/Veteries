using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface IVeterinarianRepository : IRepository<Veterinarian>
    {
        public void Update(Veterinarian veterinarian);
    }
}
