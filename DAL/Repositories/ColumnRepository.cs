using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Task = System.Threading.Tasks.Task;

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
            Db.Columns.AddAsync(item);
        }

        void IRepository<Column>.Delete(Guid Id)
        {
            var column = Db.Columns.FindAsync(Id);
            if (column.Result != null)
                Db.Columns.Remove(column.Result);
        }

        ValueTask<Column> IRepository<Column>.Read(Guid Id)
        {
            return Db.Columns.FindAsync(Id);
        }

        IEnumerable<Column> IRepository<Column>.ReadAll()
        {
            return Db.Columns;
        }

        async Task IRepository<Column>.Update(Column item)
        {
            var column = await Db.Columns.FindAsync(item.Id);

            if (column != null)
            {
                Db.Columns.Remove(column);

            }

            await Db.Columns.AddAsync(item);
        }
    }
}
