using System;

namespace BLL.Models
{
    public abstract class BaseEntityBL
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
