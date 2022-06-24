using DAL.Entities;
using System.Collections.Generic;

namespace DAL.EntityRepositories
{
    internal class ColumnRepository
    {
        private List<Column> columns;

        public ColumnRepository()
        {
            columns = new List<Column>();
        }

        public ColumnRepository(Column column)
        {
            columns = new List<Column>();
            columns.Add(column);
        }

        public void Add()
        {

        }

        public void Change()
        {

        }

        public void Delete()
        {

        }

        public void Get()
        {

        }

        public void GetAll()
        {

        }
    }
}
