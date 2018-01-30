using GoMentor.Domain.Managers;
using GoMentor.Domain.Models;
using GoMentor.Infrastructure.Entities;
using GoMentor.Infrastructure.Repositories;
using GoMentor.Infrastructure.Utilities;
using GoMentor.Web.Models;
using GoMentor.Web.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace GoMentor.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager _user;

        public IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;

        public AccountController(UserManager user)
        {
            _user = user;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogInViewModel model, string returnUrl)
        {

            //check if model state is valid
            if (ModelState.IsValid)
            {
                //Get User by log in details
                var user = _user.LogIn(model.Email, model.Password);
                
                if (user != null)
                {                  
                    //Gets user identity based on login info
                    var identity = user.GetUserIdentity();

                    var props = new AuthenticationProperties { IsPersistent = model.RememberMe };
                    Authentication.SignIn(props, identity);

                    //redirect user
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    else
                    {
                        return RedirectToAction("index", user.Role);
                    }
                }
            }

            ModelState.AddModelError("Invalid Login", "Invalid Email or Password");
            return View(model);

        }
        public ActionResult Logout()
        {
            Authentication.SignOut();
            return RedirectToAction("index", "home");
        }

        public ActionResult Signup()
        {
            var model = new SignupViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new UserModel
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                    };

                    //Add new user to Users table
                    _user.RegisterUser(user, model.Password);
                    _user.AddRole(user.UserId, 3);
                    return RedirectToAction("addbio", "mentee", new { userId = user.UserId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Invalid Registration", ex.Message);
                }
            }

            return View(model);
        }



    }
}