using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.EntityRepositories
{
    internal class UserRepository : IRepository<User>
    {
        private ApplicationContext DB;

        public UserRepository(ApplicationContext context)
        {
            DB = context;
        }

        public IEnumerable<User> ReadAll()
        {
            return DB.Users;
        }

        public User Read(Guid Id)
        {
            return DB.Users.Find(Id);
        }

        public void Create(User item)
        {
            DB.Users.Add(item);
        }

        public void Update(User item)
        {
            var previous = DB.Users.Find(item.Id);

            if (previous != null)
            {
                DB.Users.Remove(previous);

                DB.Users.Add(item);
            }
        }

        public void Delete(Guid Id)
        {
            User user = DB.Users.Find(Id);
            if (user != null)
                DB.Users.Remove(user);
        }
    }
}
