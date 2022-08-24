using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ScrumBoardApp.Models;
using ScrumBoardApp.Models.Authorization;

namespace ScrumBoardApp.Controllers.User
{
    public class AccountController : Controller
    {
        private readonly UserManager<DAL.Entities.User> _userManager;
        private readonly SignInManager<DAL.Entities.User> _signInManager;

        public AccountController(UserManager<DAL.Entities.User> userManager, SignInManager<DAL.Entities.User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: RegistrationController
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Registration(string name, string email, string password, DateTime birthDay)
        //{
        //    UserModel user = new UserModel()
        //    {
        //        Name = name,
        //        Email = email,
        //        Password = password,
        //        BirthDay = birthDay,
        //        Role = "user",
        //    };

        //    using (var db = new BllUserService())
        //    {
        //        db.AddUser(Mapper.Map<UserBL>(user));
        //    }

        //    return Redirect("~/Home/Success");
        //}

        [HttpPost]
        public async Task<IActionResult> Registration(UserModel model)
        {
            if (ModelState.IsValid)
            {
                DAL.Entities.User user = new DAL.Entities.User { Email = model.Email, UserName = model.Email, BirthDay = model.BirthDay };
                // Add Acc
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // install cookies
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("~/Home/Success");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // if has Url
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "incorrect email (or) password");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // delete cookie
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
