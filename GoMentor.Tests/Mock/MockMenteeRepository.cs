using GoMentor.Domain.Interfaces.Repositories;
using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Tests.Mock
{
    public class MockMenteeRepository : IMenteeRepository
    {
        List<MenteeModel> _mentees = new List<MenteeModel>();
        List<MentorModel> _mentors = new List<MentorModel>();
        List<CategoryModel> _categories = new List<CategoryModel>();
        public MenteeModel AddMentee(MenteeModel model, int userId)
        {
            model.UserId = userId;
            _mentees.Add(model);
            return model;

        }


        public void AssignMentor(int userId, int mentorId)
        {
            //populate mentee list
            //_mentees.Add(new MenteeModel { UserId = 1, Category = "Art" });
            //_mentees.Add(new MenteeModel { UserId = 2, Category = "Software" });


            //populate mentor list
            _mentors.Add(new MentorModel { UserId = 11, Category = "Art" });
            _mentors.Add(new MentorModel { UserId = 12, Category = "Art" });

            //populate category list
            _categories = new List<CategoryModel>
            {
                new CategoryModel{CategoryId = 1, CategoryName = "Art"},
                new CategoryModel{CategoryId = 2, CategoryName = "Software"}
            };
            //Get Mentee
            var mentee = _mentees.Find(u => u.UserId == userId);

            //Get All Mentors In the same category
            var query = from c in _categories
                        from m in _mentors
                        where m.Category == mentee.Category
                        select m;

            var mentors = query.ToArray();

            var record = from m in mentors
                         where m.UserId == mentorId
                         select m;

            var mentor = record.FirstOrDefault();
            //Assign
            mentee.Mentor = mentor;
        }

        public MenteeModel EditMentee(MenteeModel model, int userId)
        {
            throw new NotImplementedException();
        }

        public MenteeModel GetMentee(int userId)
        {
            return _mentees.FirstOrDefault(u => u.UserId == userId);
        }

        public ICollection<MenteeModel> GetMentees()
        {
            throw new NotImplementedException();
        }

        public ICollection<MenteeModel> GetMenteesByMentor(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Mentored(int userId)
        {
            var mentee = _mentees.FirstOrDefault(u => u.UserId == userId);
            if (mentee.Mentor != null)
            {
                return true;
            }

            else { return false; }
        }

        public MenteeModel[] NotMentored()
        {
            throw new NotImplementedException();
        }
    }
}
