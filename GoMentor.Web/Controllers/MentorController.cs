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
    public class MentorController : Controller
    {
        private UserManager _user;
        private ScheduleManager _schedule;
        private MentorManager _mentor;
        private MenteeManager _mentee;

        // GET: Mentor
        public MentorController(UserManager user, MentorManager mentor, ScheduleManager schedule, MenteeManager mentee)
        {
            _user = user;
            _schedule = schedule;
            _mentor = mentor;
            _mentee = mentee;

        }

        [Authorize(Roles = "Mentor")]
        public ActionResult Index()
        {
            var user = User.Identity.GetUserIdentity();
            var model = _user.GetUserById(user.UserId);
            return View(model);
        }


        public ActionResult AddBio()
        {

            var user = User.Identity.GetUserIdentity();
            var model = new MentorBioModel
            {
                User = user
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult AddBio(MentorBioModel model)
        {
            //Get user by id
            var user = User.Identity.GetUserIdentity();

            if (ModelState.IsValid)
            {
                //map out mentor model 
                var mentor = new MentorModel
                {
                    UserId = user.UserId,
                    Bio = model.Bio,
                    MobileNo = model.MobileNo,
                    Address = model.Address,
                    Gender = model.Gender,
                    Birthday = model.Birthday,
                    User = new UserModel
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    }

                };

                try
                {
                    _mentor.EditMentor(mentor, user.UserId);
                    return RedirectToAction("userprofile");
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

            var model = _mentor.GetMentor(identity.UserId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(MentorModel model)
        {
            var identity = User.Identity.GetUserIdentity();
            if (ModelState.IsValid)
            {
                try
                {
                    _mentor.EditMentor(model, identity.UserId);
                    return RedirectToAction("userprofile");
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("Failed to save", ex.Message);
                }
            }
            return View(model);

        }
        public ActionResult UserProfile()
        {
            var user = User.Identity.GetUserIdentity();

            var model = _mentor.GetMentor(user.UserId);
            if (model.Address == null)
            {
                return RedirectToAction("AddBio");
            }
            return View(model);
        }
        public ActionResult CreateSchedule()
        {
            var model = new ScheduleViewModel();

            //Get user identity
            var identity = User.Identity.GetUserIdentity();
            //Get all mentees assigned to mentor
            var mentees = _mentee.GetMentees(identity.UserId);
            //Pass it to a view bag
            ViewBag.UserId = new SelectList(mentees, "UserId", "User.FirstName", model.Mentee.UserId);
          

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateSchedule(ScheduleViewModel model)
        {
            var identity = User.Identity.GetUserIdentity();

            //Get all mentees assigned to mentor
            var mentees = _mentee.GetMentees(identity.UserId);
            //Pass it to a view bag
            ViewBag.UserId = new SelectList(mentees, "UserId", "User.FirstName", model.Mentee.UserId);

            if (ModelState.IsValid)
            {
                try
                {
                    var schedule = new ScheduleModel
                    {
                        Date = model.Date,
                        Time = model.Time,
                        Details = model.Details,
                        Mentee = new MenteeModel
                        {
                            UserId = model.Mentee.UserId,

                        },

                    };

                    _schedule.CreateSchedule(schedule, model.Mentee.UserId);
                    return RedirectToAction("schedules");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("not saved", ex.Message);
                }
            }
            return View();
        }
    }
}