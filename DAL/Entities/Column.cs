using System.Collections.Generic;

namespace DAL.Entities
{
    public class Column : BaseEntity
    {
        public ICollection<Taska> ColumnTasks { get; set; }
    }
}
