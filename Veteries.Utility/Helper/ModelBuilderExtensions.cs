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
                    ID = 1010,
                    Name = "Warszawa"
                },
                new City
                {
                    ID = 1011,
                    Name = "Kraków"
                },
                new City
                {
                    ID = 1012,
                    Name = "Lublin"
                },
                new City
                {
                    ID = 1013,
                    Name = "Poznań"
                });
        }
    }
    
}
