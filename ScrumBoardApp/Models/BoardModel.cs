using System;
using System.Collections.Generic;

namespace ScrumBoardApp.Models
{
    public class BoardModel : BaseEntityModel
    {
        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public ICollection<ColumnModel> BoardColumns { get; set; }

        public BoardModel()
        {
            Id = Guid.NewGuid();
            BoardColumns = new List<ColumnModel>();
        }

    }
}
