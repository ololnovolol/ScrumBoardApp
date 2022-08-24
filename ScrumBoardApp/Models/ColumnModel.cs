using System.Collections.Generic;

namespace ScrumBoardApp.Models
{
    public class ColumnModel : BaseEntityModel
    {
        public ICollection<TaskModel> ColumnTasks { get; set; }
    }
}
