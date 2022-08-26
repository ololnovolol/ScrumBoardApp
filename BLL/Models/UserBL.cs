using System;
using System.Collections.Generic;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Models
{
    public class UserBL : IdentityUser
    {

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime BirthDay { get; set; }

        public string Role { get; set; }


        public ICollection<Board> UserBoards { get; set; }

    }
}
