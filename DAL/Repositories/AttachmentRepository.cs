using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

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
            Db.Attachments.AddAsync(item);
        }

        void IRepository<Attachment>.Delete(Guid Id)
        {
            var atch = Db.Attachments.FindAsync(Id);
            if (atch.Result != null)
                Db.Attachments.Remove(atch.Result);
        }

        ValueTask<Attachment> IRepository<Attachment>.Read(Guid Id)
        {
            return Db.Attachments.FindAsync(Id);
        }

        IEnumerable<Attachment> IRepository<Attachment>.ReadAll()
        {
            return Db.Attachments;
        }

        async Task IRepository<Attachment>.Update(Attachment item)
        {
            var atch = await Db.Attachments.FindAsync(item.Id);

            if (atch != null)
            {
                Db.Attachments.Remove(atch);

            }

            await Db.Attachments.AddAsync(item);
        }
    }
}
