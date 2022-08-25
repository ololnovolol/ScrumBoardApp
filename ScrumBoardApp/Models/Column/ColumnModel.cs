using System;
using System.Collections.Generic;

namespace ScrumBoardApp.Models.Column
{
    public class ColumnModel : BaseEntityModel
    {
        public ICollection<TaskModel> ColumnTasks { get; set; }

        public ColumnModel()
        {
            Id = Guid.NewGuid();
            ColumnTasks = new List<TaskModel>();
        }
    }
}
