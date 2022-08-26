using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ScrumBoardApp.Models;
using ScrumBoardApp.Models.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        [HttpGet]
        [Authorize]
        public ActionResult Settings()
        {
            var currentId = _userManager.GetUserId(User);
            using (BllUserService us = new BllUserService())
            {
                var currentUser = Mapper.Map<UserModel>(us.GetUsers().FirstOrDefault(x => x.Id == currentId));
                return View(currentUser);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Settings(UserModel model)
        {
            DAL.Entities.User user = await _userManager.GetUserAsync(User);
            user.Email = model.Email;
            user.Password = model.Password;
            user.UserName = model.UserName;
            user.BirthDay = model.BirthDay;
    

            if (ModelState.IsValid)
            {
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {

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

        // GET: RegistrationController
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserModel model)
        {
            if (ModelState.IsValid)
            {

                DAL.Entities.User user = new DAL.Entities.User { Email = model.Email, UserName = model.UserName, BirthDay = model.BirthDay };
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
            else
            {
                DAL.Entities.User user = new DAL.Entities.User { Email = model.Email, UserName = model.UserName, BirthDay = model.BirthDay };
                var result = await _userManager.CreateAsync(user, model.Password);

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
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
