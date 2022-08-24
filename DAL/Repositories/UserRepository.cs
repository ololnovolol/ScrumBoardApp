using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationContext Db;

        public UserRepository(ApplicationContext context)
        {
            Db = context;
        }

        void IRepository<User>.Create(User item)
        {
            Db.Users.Add(item);
        }

        void IRepository<User>.Delete(Guid Id)
        {
            var user = Db.Users.Find(Id);
            if (user != null)
                Db.Users.Remove(user);
        }

        User IRepository<User>.Read(Guid Id)
        {
            return Db.Users.Find(Id);
        }

        IEnumerable<User> IRepository<User>.ReadAll()
        {
            return Db.Users;
        }

        void IRepository<User>.Update(User item)
        {
            var user = Db.Users.Find(item.Id);

            if (user != null)
            {
                Db.Users.Remove(user);

            }

            Db.Users.Add(item);
        }
    }
}
