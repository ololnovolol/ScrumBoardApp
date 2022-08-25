﻿using AutoMapper;
using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using ScrumBoardApp.Models;
using ScrumBoardApp.Models.Column;
using DAL.Entities;

namespace ScrumBoardApp.Controllers.Board
{
    public class BoardController : Controller
    {
        private UserManager<DAL.Entities.User> _currentUser;
        public BoardController(UserManager<DAL.Entities.User> userManager)
        {
            _currentUser = userManager;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var id = Guid.Parse(_currentUser.GetUserId(User)); // Get user id:


            List<BoardModel> list = default;

            using (var db = new BllBoardService())
                list = Mapper.Map<List<BoardModel>>(db.GetBoards().Where(b => b.UserId.Equals(id)));

            return View(list);
        }


        public IActionResult Delete()
        {


            return Index();
        }

        // GET: RegistrationController
        [HttpGet]
        [Authorize]
        public ActionResult AddBoard()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddBoard(string name, Guid userId)
        {
            
            if (User.Identity.IsAuthenticated)
            {
                string g = User.Identity.Name;

                bool IsAdmin = User.IsInRole("Admin");
                bool IsUser = User.IsInRole("User");
                bool IsMoserator = User.IsInRole("Moderator");

                var id = _currentUser.GetUserId(User); // Get user id:
            }

            BoardModel board = new BoardModel()
            {
                Name = name,
                UserId = Guid.Parse(_currentUser.GetUserId(User)), // Get user id:
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
