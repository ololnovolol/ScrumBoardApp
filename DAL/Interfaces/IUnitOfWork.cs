using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Attachment> Attachments { get; }
        IRepository<Board> Boards { get; }
        IRepository<Column> Columns { get; }
        IRepository<Task> Tasks { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}