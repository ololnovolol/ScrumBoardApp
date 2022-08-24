using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class AttachmentRepository : IRepository<Attachment>
    {
        private ApplicationContext Db;

        public AttachmentRepository(ApplicationContext context)
        {
            Db = context;
        }

        void IRepository<Attachment>.Create(Attachment item)
        {
            Db.Attachments.Add(item);
        }

        void IRepository<Attachment>.Delete(Guid Id)
        {
            Attachment atch = Db.Attachments.Find(Id);
            if (atch != null)
                Db.Attachments.Remove(atch);
        }

        Attachment IRepository<Attachment>.Read(Guid Id)
        {
            return Db.Attachments.Find(Id);
        }

        IEnumerable<Attachment> IRepository<Attachment>.ReadAll()
        {
            return Db.Attachments;
        }

        void IRepository<Attachment>.Update(Attachment item)
        {
            var atch = Db.Attachments.Find(item.Id);

            if (atch != null)
            {
                Db.Attachments.Remove(atch);

            }

            Db.Attachments.Add(item);
        }
    }
}
