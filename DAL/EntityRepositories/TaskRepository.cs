using DAL.Entities;
using System.Collections.Generic;

namespace DAL.EntityRepositories
{
    internal class TaskRepository
    {
        private List<Task> tasks;

        public TaskRepository()
        {
            tasks = new List<Task>();
        }

        public TaskRepository(Task task)
        {
            tasks = new List<Task>();
            tasks.Add(task);
        }

        public void Add()
        {

        }

        public void Change()
        {

        }

        public void Delete()
        {

        }

        public void Get()
        {

        }

        public void GetAll()
        {

        }
    }
}
