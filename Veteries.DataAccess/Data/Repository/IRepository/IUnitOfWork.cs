using System;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ISpeciesRepository Species { get; }
        void Save();
    }
}
