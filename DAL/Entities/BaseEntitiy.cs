using System;

namespace DAL.Entities
{
    public abstract class BaseEntitiy
    {
        protected Guid Id { get; set; }
        public string Name { get; set; }

        public BaseEntitiy(Guid id, string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public BaseEntitiy(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public BaseEntitiy()
        {
            Id = Guid.NewGuid();
            Name = "NaN";
        }
    }
}
