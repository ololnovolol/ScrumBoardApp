using System;
using System.Collections.Generic;
using System.Numerics;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.EntityRepositories
{
    internal class BoardRepository : IRepository<Board>
    {
        private ApplicationContext DB;

        public BoardRepository(ApplicationContext context)
        {
            DB = context;
        }

        public IEnumerable<Board> ReadAll()
        {
            return DB.Boards;
        }

        public Board Read(Guid Id)
        {
            return DB.Boards.Find(Id);
        }

        public void Create(Board item)
        {
            DB.Boards.Add(item);
        }

        public void Update(Board item)
        {
            var previousBoard = DB.Boards.Find(item.Id);

            if (previousBoard != null & previousBoard.Id == item.UserId)
            {
                DB.Boards.Remove(previousBoard);

                DB.Boards.Add(item);
            }
        }

        public void Delete(Guid Id)
        {
            Board board = DB.Boards.Find(Id);
            if (board != null)
                DB.Boards.Remove(board);
        }
    }
}
