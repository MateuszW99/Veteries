using System.Collections.Generic;
using System.Linq;
using Veteries.DataAccess.Data.Repository.IRepository;
using Veteries.Models;

namespace Veteries.DataAccess.Data.Repository
{
    public class SpeciesRepository : Repository<Species>, ISpeciesRepository
    {
        private readonly ApplicationDbContext _db;

        public SpeciesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> GetSpeciesListForDropdown()
        {
            return _db.Species.Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Species species)
        {
            var objFromDb = _db.Species.FirstOrDefault(s => s.Id == species.Id);
            
            objFromDb.Name = species.Name;
            _db.SaveChanges();
        }

    }
}
