﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Board : BaseEntity
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public ICollection<Column> BoardColumns { get; set; }

    }
}
