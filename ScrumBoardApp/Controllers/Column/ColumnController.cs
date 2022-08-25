using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScrumBoardApp.Models;
using System;
using System.Collections.Generic;
using ScrumBoardApp.Models.Column;

namespace ScrumBoardApp.Controllers.Column
{
    public class ColumnController : Controller
    {
        private readonly UserManager<DAL.Entities.User> _currentUser;

        public ColumnController(UserManager<DAL.Entities.User> userManager)
        {
            _currentUser = userManager;
        }

        // GET: RegistrationController
        [HttpGet]
        [Authorize]
        public ActionResult AddColumn()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddColumn(string name)
        {

            ColumnModel column = new ColumnModel()
            {
                Name = name,
                ColumnTasks = new List<TaskModel>()
            };

            using (var db = new BllColumnService())
            {
                db.AddColumn(Mapper.Map<ColumnBL>(column));
            }

            return Redirect("~/Home/Success");
        }
    }
}
