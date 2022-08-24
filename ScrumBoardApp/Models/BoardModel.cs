using System;
using System.Collections.Generic;

namespace ScrumBoardApp.Models
{
    public class BoardModel : BaseEntityModel
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public ICollection<ColumnModel> BoardColumns { get; set; }

    }
}
