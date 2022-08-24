using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace ScrumBoardApp.Models.Authorization
{
    public class UserModel : BaseEntityModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Passwords Confirm")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Date your birthday")]
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
