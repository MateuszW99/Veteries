using Microsoft.EntityFrameworkCore;
using Veteries.Models;

namespace Veteries.Utility.Helper
{
    public static class ModelBuilderExtensions
    {
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    ID = 2000,
                    Name = "Warszawa"
                },
                new City
                {
                    ID = 2001,
                    Name = "Kraków"
                },
                new City
                {
                    ID = 2002,
                    Name = "Lublin"
                },
                new City
                {
                    ID = 2003,
                    Name = "Poznań"
                });
        }
    }
    
}
