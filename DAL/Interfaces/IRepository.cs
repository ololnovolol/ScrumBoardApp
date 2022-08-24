using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    where T : class
    {
        IEnumerable<T> ReadAll();

        T Read(Guid Id);

        void Create(T item);

        void Update(T item);

        void Delete(Guid Id);

    }
}
