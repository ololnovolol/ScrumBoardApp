using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class TaskRepository : IRepository<Taska>
    {
        private ApplicationContext Db;

        public TaskRepository(ApplicationContext context)
        {
            Db = context;
        }

        void IRepository<Taska>.Create(Taska item)
        {
            Db.Tasks.AddAsync(item);
        }

        void IRepository<Taska>.Delete(Guid Id)
        {
            var taska = Db.Tasks.FindAsync(Id);
            if (taska.Result != null)
                Db.Tasks.Remove(taska.Result);
        }

        ValueTask<Taska> IRepository<Taska>.Read(Guid Id)
        {
            return Db.Tasks.FindAsync(Id);
        }

        IEnumerable<Taska> IRepository<Taska>.ReadAll()
        {
            return Db.Tasks;
        }

        async Task IRepository<Taska>.Update(Taska item)
        {
            var taska = await Db.Tasks.FindAsync(item.Id);

            if (taska != null)
            {
                Db.Tasks.Remove(taska);

            }

            await Db.Tasks.AddAsync(item);
        }
    }
}
