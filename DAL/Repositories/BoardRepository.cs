using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DAL.Repositories
{
    internal class BoardRepository : IRepository<Board>
    {
        private ApplicationContext Db;

        public BoardRepository(ApplicationContext context)
        {
            Db = context;
        }

        void IRepository<Board>.Create(Board item)
        {
            Db.AddAsync(item);
        }

        void IRepository<Board>.Delete(Guid Id)
        {
            var board = Db.Boards.FindAsync(Id);
            if (board.Result != null)
                Db.Boards.Remove(board.Result);
        }

        ValueTask<Board> IRepository<Board>.Read(Guid Id)
        {
            return Db.Boards.FindAsync(Id);
        }

        IEnumerable<Board> IRepository<Board>.ReadAll()
        {
            return Db.Boards;
        }

        async Task IRepository<Board>.Update(Board item)
        {
            var board = await Db.Boards.FindAsync(item.Id);

            if (board != null)
            {
                item.DateCreated = board.DateCreated;
                Db.Boards.Remove(board);

            }

            await Db.Boards.AddAsync(item);
        }
    }
}
