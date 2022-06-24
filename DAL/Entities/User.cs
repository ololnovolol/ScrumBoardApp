using System;

namespace DAL.Entities
{
    public class User : BaseEntitiy
    {
        protected string email { get; set; }
        protected string password { get; set; }
        public DateTime birthDay { get; set; }
        public string role { get; set; }

        public User() : base()
        {
            role = "user";
        }

        public User(Guid id, string name, string email, string password, DateTime birthDay)
            : base(id,name)
        {
            this.email = email;
            this.password = password;
            this.birthDay = birthDay;
            this.role = "user";
        }

        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
            role = "user";
        }
    }
}
