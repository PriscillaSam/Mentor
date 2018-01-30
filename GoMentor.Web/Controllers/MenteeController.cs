using GoMentor.Domain.Managers;
using GoMentor.Domain.Models;
using GoMentor.Web.Infrastructure;
using GoMentor.Web.Models;
using GoMentor.Web.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GoMentor.Web.Controllers
{
    // [Authorize(Roles = "Mentee")]
    public class MenteeController : Controller
    {
        private UserManager _user;
        private MenteeManager _mentee;
        private ScheduleManager _schedule;

        public IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public MenteeController(UserManager user, MenteeManager mentee, ScheduleManager schedule)
        {
            _user = user;
            _mentee = mentee;
            _schedule = schedule;
        }
        [Authorize(Roles = "Mentee")]
        public ActionResult Index()
        {
            var user = User.Identity.GetUserIdentity();

            var model = _mentee.GetMentee(user.UserId);
            return View(model);
        }

     
        public ActionResult AddBio(int userId)
        {
            var model = new MenteeBioModel();
            var categories = _user.GetCategories();
            model.Categories = GetSelectListItems(categories);

            //Get user by id and pass user to the view

            model.User = _user.GetUserById(userId);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBio(MenteeBioModel model, int userId)
        {
            //Get user by id
            var user = _user.GetUserById(userId);
            //Populate Category Dropdown List
            var categories = _user.GetCategories();
            model.Categories = GetSelectListItems(categories);

            if (ModelState.IsValid)
            {
                try
                {
                    //Map MenteeBio info to mentee table
                    var mentee = new MenteeModel
                    {
                        UserId = user.UserId,
                        Address = model.Address,
                        Birthday = model.Birthday,
                        Gender = model.Gender,
                        MobileNo = model.MobileNo,
                        Bio = model.Bio,
                        Category = model.Category
                    };

                    _mentee.AddMentee(mentee, user.UserId);
                    //Trying to log user in immediately after adding profile
                    var identity =  user.GetUserIdentity();
                    AuthenticationManager.SignIn(identity);
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Invalid Reg", ex.Message);
                }

            }
            return View(model);
        }

        public ActionResult Edit()
        {
            //Get User Identity
            var identity = User.Identity.GetUserIdentity();

            var model = _mentee.GetMentee(identity.UserId);
         
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MenteeModel model)
        {
            var identity = User.Identity.GetUserIdentity();
            if (ModelState.IsValid)
            {
                try
                {
                    _mentee.EditMentee(model, identity.UserId);
                    return RedirectToAction("userprofile");
                }

                catch(Exception ex)
                {
                    ModelState.AddModelError("Failed to save", ex.Message);
                }
            }
            return View(model);

        }

        public ActionResult UserProfile()
        {
            var user = User.Identity.GetUserIdentity();

            var model = _mentee.GetMentee(user.UserId);          

            return View(model);
        }

        public ActionResult Schedules()
        {
            var user = User.Identity.GetUserIdentity();
            var schedules = _schedule.GetSchedules(user.UserId);
            return View(schedules);
        }
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<CategoryModel> categories)
        {
            //Create new SelectListItem 
            var selectList = new List<SelectListItem>();

            //Iterate over an IEnumerable of category model
            foreach (var element in categories)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.CategoryName,
                    Text = element.CategoryName
                });
            }

            return selectList;
        }

    }
}