using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class ColumnRepository : IRepository<Column>
    {
        private ApplicationContext Db;

        public ColumnRepository(ApplicationContext context)
        {
            Db = context;
        }

        void IRepository<Column>.Create(Column item)
        {
            Db.Columns.Add(item);
        }

        void IRepository<Column>.Delete(Guid Id)
        {
            var column = Db.Columns.Find(Id);
            if (column != null)
                Db.Columns.Remove(column);
        }

        Column IRepository<Column>.Read(Guid Id)
        {
            return Db.Columns.Find(Id);
        }

        IEnumerable<Column> IRepository<Column>.ReadAll()
        {
            return Db.Columns;
        }

        void IRepository<Column>.Update(Column item)
        {
            var column = Db.Columns.Find(item.Id);

            if (column != null)
            {
                Db.Columns.Remove(column);

            }

            Db.Columns.Add(item);
        }
    }
}
