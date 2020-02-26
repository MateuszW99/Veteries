using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        void LockUnlock(ApplicationUser applicationUser);
    }
}
