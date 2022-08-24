using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class BoardBL : BaseEntityBL
    {
        public Guid UserId { get; set; } 

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public ICollection<ColumnBL> BoardColumns { get; set; }

    }
}
