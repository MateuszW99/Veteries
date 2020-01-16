using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient patient);
    }
}
