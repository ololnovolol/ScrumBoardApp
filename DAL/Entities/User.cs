﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string Role { get; set; }

        public ICollection<Board> UserBoards { get; set; }

    }
}
