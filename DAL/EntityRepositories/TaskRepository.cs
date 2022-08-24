using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.EntityRepositories
{
    internal class TaskRepository : IRepository<Task>
    {
        private ApplicationContext DB;

        public TaskRepository(ApplicationContext context)
        {
            DB = context;
        }

        public IEnumerable<Task> ReadAll()
        {
            return DB.Tasks;
        }

        public Task Read(Guid Id)
        {
            return DB.Tasks.Find(Id);
        }

        public void Create(Task item)
        {
            DB.Tasks.Add(item);
        }

        public void Update(Task item)
        {
            var previous = DB.Tasks.Find(item.Id);

            if (previous != null)
            {
                DB.Tasks.Remove(previous);

                DB.Tasks.Add(item);
            }
        }

        public void Delete(Guid Id)
        {
            Task temp = DB.Tasks.Find(Id);
            if (temp != null)
                DB.Tasks.Remove(temp);
        }
    }
}
