using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class TaskBL : BaseEntityBL
    {
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ICollection<AttachmentBL> AttachmentsTask { get; set; }
    }
}
