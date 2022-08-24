using System;

namespace ScrumBoardApp.Models
{
    public abstract class BaseEntityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
