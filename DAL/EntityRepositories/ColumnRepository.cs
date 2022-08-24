using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.EntityRepositories
{
    internal class ColumnRepository : IRepository<Column>
    {
        private ApplicationContext DB;

        public ColumnRepository(ApplicationContext context)
        {
            DB = context;
        }

        public IEnumerable<Column> ReadAll()
        {
            return DB.Columns;
        }

        public Column Read(Guid Id)
        {
            return DB.Columns.Find(Id);
        }

        public void Create(Column item)
        {
            DB.Columns.Add(item);
        }

        public void Update(Column item)
        {
            var previous = DB.Columns.Find(item.Id);

            if (previous != null)
            {
                DB.Columns.Remove(previous);

                DB.Columns.Add(item);
            }
        }

        public void Delete(Guid Id)
        {
            Column column = DB.Columns.Find(Id);
            if (column != null)
                DB.Columns.Remove(column);
        }
    }
}