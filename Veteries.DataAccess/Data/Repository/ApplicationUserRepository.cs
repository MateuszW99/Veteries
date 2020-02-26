using System;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;
using Veteries.Utility.Helper;

namespace Veteries.DataAccess.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void LockUnlock(ApplicationUser applicationUser)
        {
            if (applicationUser.LockoutEnd != null && applicationUser.LockoutEnd > DateTime.Now)
            {
                applicationUser.LockoutEnd = DateTime.Now;
            }
            else
            {
                applicationUser.LockoutEnd = DateTime.Now.AddYears(StaticDetails.LockTime);
            }
        }
    }
}
