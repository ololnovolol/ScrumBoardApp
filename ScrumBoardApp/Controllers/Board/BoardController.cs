using AutoMapper;
using BLL.Models;
using BLL.Services;
using ScrumBoardApp.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ScrumBoardApp.Controllers.Board
{
    public class BoardController : Controller
    {

        // GET: RegistrationController
        [HttpGet]
        public ActionResult AddBoard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBoard(string name, Guid userId)
        {
            BoardModel board = new BoardModel()
            {
                Name = name,
                UserId = userId,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            using (var db = new BllBoardService())
            {
                db.AddBoard(Mapper.Map<BoardBL>(board));
            }

            return Redirect("~/Home/Success");
        }
    }
}
