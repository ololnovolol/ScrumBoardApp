using System.Collections.Generic;

namespace BLL.Models
{
    public class ColumnBL : BaseEntityBL
    {
        public ICollection<TaskBL> ColumnTasks { get; set; }
    }
}
