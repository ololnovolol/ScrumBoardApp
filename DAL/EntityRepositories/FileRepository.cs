using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace DAL.EntityRepositories
{
    internal class FileRepository : IRepository<Attachment>
    {
        private ApplicationContext DB;

        public FileRepository(ApplicationContext context)
        {
            DB = context;
        }

        public IEnumerable<Attachment> ReadAll()
        {
            return DB.Attachments;
        }

        public Attachment Read(Guid Id)
        {
            return DB.Attachments.Find(Id);
        }

        public void Create(Attachment item)
        {
            DB.Attachments.Add(item);
        }

        public void Update(Attachment item)
        {
            var previous = DB.Attachments.Find(item.Id);

            if (previous != null)
            {
                DB.Attachments.Remove(previous);

                DB.Attachments.Add(item);
            }
        }

        public void Delete(Guid Id)
        {
            Attachment temp = DB.Attachments.Find(Id);
            if (temp != null)
                DB.Attachments.Remove(temp);
        }
    }
}
