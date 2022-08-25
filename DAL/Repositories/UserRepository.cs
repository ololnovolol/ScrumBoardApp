using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            Db.Users.AddAsync(item);
        }

        void IRepository<User>.Delete(Guid Id)
        {
            var user = Db.Users.FindAsync(Id);
            if (user.Result != null)
                Db.Users.Remove(user.Result);
        }

        ValueTask<User> IRepository<User>.Read(Guid Id)
        {
            return Db.Users.FindAsync(Id);
        }

        IEnumerable<User> IRepository<User>.ReadAll()
        {
            return Db.Users;
        }

        async Task IRepository<User>.Update(User item)
        {
            var user = await Db.Users.FindAsync(item.Id);

            if (user != null)
            {
                Db.Users.Remove(user);

            }

            await Db.Users.AddAsync(item);
        }
    }
}
