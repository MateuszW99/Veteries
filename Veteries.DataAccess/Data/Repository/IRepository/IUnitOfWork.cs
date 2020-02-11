﻿using System;

namespace Veteries.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ISpeciesRepository Species { get; }
        IPatientRepository Patient { get; }
        ICustomerRepository Customer { get; }
        void Save();
    }
}
