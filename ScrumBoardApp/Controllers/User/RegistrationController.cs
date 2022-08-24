using System;
using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ScrumBoardApp.Models;

namespace ScrumBoardApp.Controllers.User
{
    public class RegistrationController : Controller
    {
        private IConfiguration configuration;


        public RegistrationController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: RegistrationController
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(string name, string email, string password, DateTime birthDay)
        {
            UserModel user = new UserModel()
            {
                Name = name,
                Email = email,
                Password = password,
                BirthDay = birthDay,
                Role = "user",
            };

            using (var db = new BllUserService(configuration))
            {
                db.AddUser(Mapper.Map<UserBL>(user));
            }

            return Redirect("~/Home/Success");
        }

    }
}
