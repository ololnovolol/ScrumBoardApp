using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class UserBL : BaseEntityBL
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime BirthDay { get; set; }

        public string Role { get; set; }


        public ICollection<Board> UserBoards { get; set; }

    }
}
