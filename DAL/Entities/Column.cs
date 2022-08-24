using System.Collections.Generic;

namespace DAL.Entities
{
    public class Column : BaseEntity
    {
        public ICollection<Task> ColumnTasks { get; set; }
    }
}
