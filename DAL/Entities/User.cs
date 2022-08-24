using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class User : IdentityUser
    {
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime BirthDay { get; set; }

        public string Role { get; set; }

        public ICollection<Board> UserBoards { get; set; }

    }
}
