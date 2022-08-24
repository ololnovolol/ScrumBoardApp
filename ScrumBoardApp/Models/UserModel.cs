using System;
using System.Collections.Generic;
using DAL.Entities;

namespace ScrumBoardApp.Models
{
    public class UserModel : BaseEntityModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string Role { get; set; }

        public ICollection<Board> UserBoards { get; set; }

        public UserModel()
        {
            UserBoards = new List<Board>();
            Id = Guid.NewGuid();
        }

    }
}
