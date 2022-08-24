using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext DataBase { get; }
        private AttachmentRepository AtchRepo;
        private BoardRepository BoardRepo;
        private ColumnRepository ColumnRepo;
        private TaskRepository TaskRepo;
        private UserRepository UserRepo;

        public UnitOfWork()
        {
            DataBase = new ApplicationContext();
        }

        public IRepository<Board> Boards
        {
            get
            {
                if (BoardRepo == null)
                    BoardRepo = new BoardRepository(DataBase);
                return BoardRepo;
            }
        }

        public IRepository<Column> Columns
        {
            get
            {
                if (ColumnRepo == null)
                    ColumnRepo = new ColumnRepository(DataBase);
                return ColumnRepo;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (UserRepo == null)
                    UserRepo = new UserRepository(DataBase);
                return UserRepo;
            }
        }

        IRepository<Entities.Attachment> IUnitOfWork.Attachments
        {
            get
            {
                if (AtchRepo == null)
                    AtchRepo = new AttachmentRepository(DataBase);
                return AtchRepo;
            }
        }

        IRepository<Entities.Task> IUnitOfWork.Tasks
        {
            get
            {
                if (TaskRepo == null)
                    TaskRepo = new TaskRepository(DataBase);
                return TaskRepo;
            }
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
