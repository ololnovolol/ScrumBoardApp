using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Taska : BaseEntity
    {
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ICollection<Attachment> AttachmentsTask { get; set; }
    }
}
