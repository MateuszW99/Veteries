using System;
using System.Collections.Generic;
using System.Text;
using Veteries.DataAccess.Data.Repository;
using Veteries.DataAccess.Data.Repository.IRepository;

namespace Veteries.DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Species = new SpeciesRepository(_db);
        }

        public ISpeciesRepository Species { get; private set; }
        public IPatientRepository Patient { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
