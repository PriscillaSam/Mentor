using GoMentor.Domain.Managers;
using GoMentor.Infrastructure.Entities;
using GoMentor.Infrastructure.Repositories;
using GoMentor.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GoMentor.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager _user;

        public IAuthenticationManager Authentication => HttpContext.GetOwinContext().Authentication;
        // GET: Account
        public AccountController()
        {
            _user = new UserManager(new UserRepository(new DataEntities()));
        }
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInViewModel model, string returnUrl)
        {
            //check if model state is valid
            if (ModelState.IsValid)
            {
                var user = _user.LogIn(model.Email, model.Password);
                //
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                    };

                    //Check to see the roles of User
                    var roles = user.Roles.Select(r => new Claim(ClaimTypes.Role, r));
                    claims.AddRange(roles);

                    //Sign user in based on the identity provided
                    var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                    var props = new AuthenticationProperties { IsPersistent = model.RememberMe };
                    Authentication.SignIn(props, identity);

                    //redirect user
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    else
                    {
                        return RedirectToAction("index","home");
                    }
                }
            } 

            ModelState.AddModelError("Invalid Login", "Invalid Email or Password");
            return View(model);
          
        }
        public ActionResult LogOut()
        {
            Authentication.SignOut();
            return RedirectToAction("login");
        }


        //SignIn Method
        private void SignIn(LogInViewModel model)
        {

        }
    }
}