using GoMentor.Domain.Managers;
using GoMentor.Domain.Models;
using GoMentor.Web.Infrastructure;
using GoMentor.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoMentor.Web.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private UserManager _user;
        private MenteeManager _mentee;
        private MentorManager _mentor;

        public AdminController(UserManager user, MenteeManager mentee, MentorManager mentor)
        {
            _user = user;
            _mentee = mentee;
            _mentor = mentor;
        }
        // GET: Admin
        public ActionResult Index(AdminViewModel model)
        {
            model.Admin = User.Identity.GetUserIdentity();
            model.Users = _mentee.GetNotMentored();
            return View(model);
        }

        public ActionResult SignUpMentor()
        {
            var model = new MentorSignUpViewModel();

            //Populate Category Dropdown List
            var categories = _user.GetCategories();
            model.Categories = GetSelectListItems(categories);
            return View(model);
        }

        [HttpPost]
        public ActionResult SignUpMentor(MentorSignUpViewModel model)
        {
            //Populate Category Dropdown List
            var categories = _user.GetCategories();
            model.Categories = GetSelectListItems(categories);
            //ViewBag.Category = new SelectList(_user.GetCategories(), "CategoryName", "CategoryName", model.Category);

            if (ModelState.IsValid)
            {
                try
                {
                    var user_mentor = new UserModel
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                    };

                    //Register User
                    _user.RegisterUser(user_mentor, "password");
                    _user.AddRole(user_mentor.UserId, 2);

                    //Register user as mentor
                    _mentor.AddMentor(new MentorModel
                    {
                        UserId = user_mentor.UserId,
                        Category = model.Category
                    });

                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Invalid Registration", ex.Message.ToString());

                }
            }

            //return viewModel if registration is unsuccessful
            return View(model);
        }

        public ActionResult NotMentored()
        {
            //Get list of currently not mentored mentees
            var model = _mentee.GetNotMentored();
            return View(model);
        }

        public ActionResult Assign(int userId)
        {
            //Get Mentee
            var mentee = _mentee.GetMentee(userId);
            var model = new AssignViewModel
            {
                Mentee = mentee
            };

            //Get Mentor List in that category
            var mentors = _mentor.GetMentorsByCategory(mentee.Category);
            ViewBag.UserId = new SelectList(mentors, "UserId", "User.FirstName", model.Mentor.UserId);

            //model.Mentors = GetSelectListItems(mentors);

            //return model
            return View(model);
        }

        [HttpPost]
        public ActionResult Assign(AssignViewModel model)
        {
            var mentee = model.Mentee;
            mentee = _mentee.GetMentee(mentee.UserId);
            var mentor = model.Mentor;

            var mentors = _mentor.GetMentorsByCategory(mentee.Category);
            ViewBag.UserId = new SelectList(mentors, "UserId", "User.FirstName", model.Mentor.UserId);


            try
            {
                _mentee.AssignMentor(mentee, mentor.UserId);
                return RedirectToAction("notmentored");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("invalid", ex.Message);
            }
            return View(model);
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
        public IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<MentorModel> mentors)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in mentors)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.UserId.ToString(),
                    Text = element.User.FirstName + " " + element.User.LastName
                });
            }

            return selectList;
        }
    }
}