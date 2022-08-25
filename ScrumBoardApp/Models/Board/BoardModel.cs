using System;
using System.Collections.Generic;
using ScrumBoardApp.Models.Column;

namespace ScrumBoardApp.Models
{
    public class BoardModel : BaseEntityModel
    {
        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public ICollection<ColumnModel> BoardColumns { get; set; }


    }
}
