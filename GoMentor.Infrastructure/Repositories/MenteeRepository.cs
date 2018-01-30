using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using GoMentor.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Repositories
{
    public class MenteeRepository : IMenteeRepository
    {
        private DataEntities _context;
        public MenteeRepository(DataEntities context)
        {
            _context = context;
        }

        public MenteeModel AddMentee(MenteeModel model, int userId)
        {
            //Get category
            var query = from c in _context.Categories
                        where c.CategoryName == model.Category
                        select c;

            //Select first matching record
            var category = query.FirstOrDefault();

            //Get User from database
            var user = _context.Users.Find(userId);

            //Check if record is null
            if (user == null)
            {
                throw new Exception("This user doesnt exist");
            }

            var mentee = new Mentee
            {
                UserId = user.UserId,
                Birthday = model.Birthday,
                Gender = model.Gender,
                Address = model.Address,
                MobileNo = model.MobileNo,
                Bio = model.Bio,
                Category = category
            };

            _context.Mentees.Add(mentee);
            _context.SaveChanges();
            return model;
        }

        public void AssignMentor(int userId, int mentorId)
        {
            //Get Mentee
            var mentee = _context.Mentees.Find(userId);
            //GEt Mentor
            var mentor = _context.Mentors.Find(mentorId);
            //Assign
            mentee.Mentor = mentor;
            _context.Entry(mentee).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public MenteeModel GetMentee(int userId)
        {
            //Get user from database 

            var record = _context.Mentees.Find(userId);

            //Check if user Exists
            if (record != null)
            {
                //transform Mentee record to MenteeModel
                var model = new MenteeModel
                {
                    UserId = record.UserId,
                    User = new UserModel
                    {
                        FirstName = record.User.FirstName,
                        LastName = record.User.LastName,
                        Email = record.User.Email
                    },

                    Address = record.Address,
                    Birthday = record.Birthday,
                    Gender = record.Gender,
                    MobileNo = record.MobileNo,
                    Bio = record.Bio,
                    Category = record.Category.CategoryName


                };
                if (record.Mentor != null)
                {
                    model.Mentor = new MentorModel
                    {
                        User = new UserModel
                        {
                            FirstName = record.Mentor.User.FirstName,
                            LastName = record.Mentor.User.LastName,
                            Email = record.Mentor.User.Email
                        }
                    };
                }

                return model;
            }

            return null;

        }

        public MenteeModel EditMentee(MenteeModel model, int userId)
        {
            var mentee = _context.Mentees.Find(userId);

            if (mentee != null)
            {
                //map model fields to mentee
                mentee.User.FirstName = model.User.FirstName;
                mentee.User.LastName = model.User.LastName;

                mentee.MobileNo = model.MobileNo;
                mentee.Address = model.Address;
                mentee.Bio = model.Bio;
                mentee.Birthday = model.Birthday;
                mentee.MobileNo = model.MobileNo;

                _context.Entry(mentee).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return new MenteeModel();
        }



        /// <summary>
        /// This method checks for mentees without mentors assigned
        /// </summary>
        /// <returns>MentorModel[]</returns>
        public MenteeModel[] NotMentored()
        {
            //Get all mentees without mentors
            var query = from mentee in _context.Mentees
                        where mentee.Mentor == null
                        select new MenteeModel
                        {
                            UserId = mentee.UserId,
                            User = new UserModel
                            {
                                FirstName = mentee.User.FirstName,
                                LastName = mentee.User.LastName,
                                Email = mentee.User.Email,
                            },
                            Category = mentee.Category.CategoryName

                        };

            var mentees = query.ToArray();
            return mentees;
        }

        public bool Mentored(int userId)
        {
            //Get Mentee by id
            var mentee = _context.Mentees.Find(userId);

            //Check if Mentor Exists
            if (mentee.Mentor != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<MenteeModel> GetMenteesByMentor(int userId)
        {
            //Get mentees with mentor userId
            var query = from m in _context.Mentees
                        where m.Mentor.UserId == userId
                        select m;

            var records = query.ToArray();

            if (records == null)
            {
                return null;
            }

            var mentees = from r in records
                          select new MenteeModel
                          {
                              UserId = r.UserId,
                              User = new UserModel
                              {
                                  UserId = r.UserId,
                                  FirstName = r.User.FirstName,
                                  LastName = r.User.LastName,
                                  Email = r.User.Email
                              }
                          };

            return mentees.ToArray();
        }
    }
}
