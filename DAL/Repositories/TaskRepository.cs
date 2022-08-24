using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private ApplicationContext Db;

        public TaskRepository(ApplicationContext context)
        {
            Db = context;
        }

        void IRepository<Task>.Create(Task item)
        {
            Db.Tasks.Add(item);
        }

        void IRepository<Task>.Delete(Guid Id)
        {
            var taska = Db.Tasks.Find(Id);
            if (taska != null)
                Db.Tasks.Remove(taska);
        }

        Task IRepository<Task>.Read(Guid Id)
        {
            return Db.Tasks.Find(Id);
        }

        IEnumerable<Task> IRepository<Task>.ReadAll()
        {
            return Db.Tasks;
        }

        void IRepository<Task>.Update(Task item)
        {
            var taska = Db.Tasks.Find(item.Id);

            if (taska != null)
            {
                Db.Tasks.Remove(taska);

            }

            Db.Tasks.Add(item);
        }
    }
}
