using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BllColumnService : IDisposable
    {
        private UnitOfWork DB { get; }

        public BllColumnService()
        {
            DB = new UnitOfWork();
        }


        public void AddColumn(ColumnBL element)
        {
            DB.Columns.Create(item: Mapper.Map<Column>(element));
            DB.Save();
        }

        public void UpdateColumn(ColumnBL element)
        {
            var toUpdate = DB.Columns.Read(element.Id).Result;

            if (toUpdate != null)
            {
                toUpdate = Mapper.Map<Column>(element);
                DB.Columns.Update(toUpdate);
                DB.Save();
            }
        }

        public void RemoveColumn(Guid Id)
        {
            DB.Columns.Delete(Id);
            DB.Save();
        }

        public IEnumerable<ColumnBL> GetColumns()
        {
            List<ColumnBL> result = new List<ColumnBL>();

            foreach (var item in DB.Columns.ReadAll())
                result.Add(item: Mapper.Map<ColumnBL>(item));

            return result;
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
