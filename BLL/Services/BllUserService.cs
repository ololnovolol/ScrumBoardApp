using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Models;

namespace BLL.Services
{
    public class BllUserService : IDisposable
    {
        private UnitOfWork DB { get; }

        public BllUserService()
        {
            DB = new UnitOfWork();
        }


        public bool AddUser(UserBL element)
        {
            DB.Users.Create(item: Mapper.Map<User>(element));
            DB.Save();
            return true;
        }

        public void UpdateUser(UserBL element)
        {
            var toUpdate = DB.Users.Read(Id: element.Id).Result;

            if (toUpdate != null)
            {
                toUpdate = Mapper.Map<User>(element);
                DB.Users.Update(toUpdate);
                DB.Save();
            }
        }

        public void RemoveUser(Guid Id)
        {
            DB.Users.Delete(Id);
            DB.Save();
        }

        public IEnumerable<UserBL> GetUsers()
        {
            List<UserBL> result = new List<UserBL>();

            foreach (var item in DB.Users.ReadAll())
                result.Add(item: Mapper.Map<UserBL>(item));

            return result;
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
