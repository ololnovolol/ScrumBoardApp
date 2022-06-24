using DAL.Entities;
using System.Collections.Generic;

namespace DAL.EntityRepositories
{
    internal class UserRepository
    {
        private List<User> users;

        public UserRepository()
        {
            users = new List<User>();
        }

        public UserRepository(User user)
        {
            users = new List<User>();
            users.Add(user);
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
