using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class BoardBL : BaseEntityBL
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public ICollection<ColumnBL> BoardColumns { get; set; }

    }
}
