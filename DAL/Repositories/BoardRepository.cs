using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

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
            Db.Boards.Add(item);
        }

        void IRepository<Board>.Delete(Guid Id)
        {
            Board board = Db.Boards.Find(Id);
            if (board != null)
                Db.Boards.Remove(board);
        }

        Board IRepository<Board>.Read(Guid Id)
        {
            return Db.Boards.Find(Id);
        }

        IEnumerable<Board> IRepository<Board>.ReadAll()
        {
            return Db.Boards;
        }

        void IRepository<Board>.Update(Board item)
        {
            var board = Db.Boards.Find(item.Id);

            if (board != null)
            {
                Db.Boards.Remove(board);

            }

            Db.Boards.Add(item);
        }
    }
}
