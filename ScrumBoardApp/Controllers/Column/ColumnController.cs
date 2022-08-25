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
using System.Linq;

namespace ScrumBoardApp.Controllers.Column
{
    public class ColumnController : Controller
    {

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {

            List<ColumnModel> list = default;

            using (var db = new BllColumnService())
                list = Mapper.Map<List<ColumnModel>>(db.GetColumns());

            return View(list);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(Guid Id)
        {
            //Guid id = Guid.Parse(Id);
            using (var db = new BllColumnService())
                db.RemoveColumn(Id);

            return RedirectToAction("Index", "Column");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Details()
        {
            // TODO realize
            return RedirectToAction("Index", "Column");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(ColumnModel update)
        {

            using (var db = new BllColumnService())
                db.UpdateColumn(Mapper.Map<ColumnBL>(update));

            return RedirectToAction("Index", "Column");
        }

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
                Id = Guid.NewGuid(),
                Name = name,
                ColumnTasks = new List<TaskModel>()
            };

            using (var db = new BllColumnService())
            {
                db.AddColumn(Mapper.Map<ColumnBL>(column));
            }

            return RedirectToAction("Index", "Column");
        }
    }
}
