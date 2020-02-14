using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
