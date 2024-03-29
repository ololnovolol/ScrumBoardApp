﻿using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BllBoardService : IDisposable
    {
        private UnitOfWork DB { get; }

        public BllBoardService()
        {
            DB = new UnitOfWork();
        }


        public void AddBoard(BoardBL element)
        {
            DB.Boards.Create(item: Mapper.Map<Board>(element));
            DB.Save();
        }

        public void UpdateBoard(BoardBL element)
        {
            var toUpdate = DB.Boards.Read(element.Id).Result;

            if (toUpdate != null)
            {
                toUpdate = Mapper.Map<Board>(element);
                DB.Boards.Update(toUpdate);
                DB.Save();
            }
        }

        public void RemoveBoard(Guid Id)
        {
            DB.Boards.Delete(Id);
            DB.Save();
        }

        public IEnumerable<BoardBL> GetBoards()
        {
            List<BoardBL> result = new List<BoardBL>();

            foreach (var item in DB.Boards.ReadAll())
                result.Add(item: Mapper.Map<BoardBL>(item));

            return result;
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}

