using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Veteries.Models;

namespace Veteries.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Species> Species { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Veterinarian> Veterinarian { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
