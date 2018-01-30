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
    public class MentorRepository : IMentorRepository
    {

        private DataEntities _context;

        public MentorRepository(DataEntities context)
        {
            _context = context;
        }

        public void AddMentor(MentorModel model)
        {
            //Get Category
            var category = from c in _context.Categories
                           where c.CategoryName == model.Category
                           select c;

            //Check if mentor record already exists
            var query = from user in _context.Mentors
                        where user.UserId == model.UserId
                        select user;

            var record = query.FirstOrDefault();

          

            //Add Mentor Record
            if (record != null)
            {
                throw new Exception("Mentor Record Already Exists");
            }

            var mentor = new Mentor
            {
                UserId = model.UserId,
                Birthday = new DateTime(2000, 10, 5),
                CategoryId = category.FirstOrDefault().CategoryId,
            };

            _context.Mentors.Add(mentor);
            _context.SaveChanges();
        }

        public MentorModel EditMentor(MentorModel model,int userId)
        {

            var mentor = _context.Mentors.Find(userId);

            if (mentor != null)
            {
                //map model fields to mentor
                mentor.User.FirstName = model.User.FirstName;
                mentor.User.LastName = model.User.LastName;

                mentor.Address = model.Address;
                mentor.Gender = model.Gender;
                mentor.Bio = model.Bio;
                mentor.Birthday = model.Birthday;
                mentor.MobileNo = model.MobileNo;

                _context.Entry(mentor).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return new MentorModel();
        }


        //This Method uses query to get a single mentor from the database
        public MentorModel GetMentor(int userId)
        {
            //Get mentor by userId
            var query = from user in _context.Mentors
                        where user.UserId == userId
                        select user;
                      


            var mentor = query.FirstOrDefault();
            if (mentor != null)
            {
                var model = new MentorModel
                {
                    UserId = mentor.UserId,
                    User = new UserModel
                    {
                      FirstName = mentor.User.FirstName,
                      LastName = mentor.User.LastName,
                      Email = mentor.User.Email
                    },

                    Address = mentor.Address,
                    Bio = mentor.Bio,
                    Birthday = mentor.Birthday,
                    Category = mentor.Category.CategoryName,
                    Gender = mentor.Gender,
                    MobileNo = mentor.MobileNo

                };

                return model;
            }

            return null;

        }

        //Im not sure if this is the right approach to this
        public UserModel[] GetMentors()
        {
            //Query to get all mentors and their corresponding user object
            var query = from user in _context.Users                        
                        from mentor in _context.Mentors
                        where mentor.UserId == user.UserId
                        select new UserModel
                        {
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Image = user.Image
                            
                        };

            var records = query.ToArray();
            if(records == null)
            {
                throw new Exception("There are no mentor records in the database");
            }

            return records;
            
        }

        public MentorModel[] GetMentorsByCategory(string category)
        {

            //Write Query
            var query = from mentor in _context.Mentors
                        where mentor.Category.CategoryName == category
                        select mentor;

            var records = query.ToArray();
            if(records == null)
            {
                throw new Exception("There are no mentor records for this category");
            }

            var mentors = from m in records
                          select new MentorModel
                          {
                              UserId = m.UserId,
                              User = new UserModel
                              {
                                  FirstName = m.User.FirstName,
                                  LastName = m.User.LastName,
                                  Email = m.User.Email,

                              }
                          };

            return mentors.ToArray();

        }
    }
}

