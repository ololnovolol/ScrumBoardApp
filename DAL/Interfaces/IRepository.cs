using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    where T : class
    {
        IEnumerable<T> ReadAll();

        ValueTask<T> Read(Guid Id);

        void Create(T item);

        Task Update(T item);

        void Delete(Guid Id);

    }
}
