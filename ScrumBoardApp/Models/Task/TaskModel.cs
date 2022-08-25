using System;
using System.Collections.Generic;
using ScrumBoardApp.Models.Attachment;

namespace ScrumBoardApp.Models
{
    public class TaskModel : BaseEntityModel
    {
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public ICollection<AttachmentModel> AttachmentsTask { get; set; }

        public TaskModel()
        {
            Id = Guid.NewGuid();
            AttachmentsTask = new List<AttachmentModel>();
        }

    }
}
